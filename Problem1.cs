public class RottenOranges
    {
        // Time Complexity : O(m * n) - have to traverse entire matrix
        // Space Complexity : O(m * n) - queue will have almost all elements from matrix in the worst case 
        // Did this code successfully run on Leetcode : Yes
        // Any problem you faced while coding this : No
        public int OrangesRotting(int[][] grid)
        {
            Queue<int[]> q = new Queue<int[]>();
            int m = grid.Length;
            int n = grid[0].Length;
            int freshOrangesCount = 0;
            int timeElapsed = 0;

            //put the rotten oranges into queue and count the fresh oranges
            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if(grid[i][j] == 2)
                    {
                        q.Enqueue(new int[] { i, j });
                    }
                    else if(grid[i][j] == 1)
                    {
                        freshOrangesCount++;
                    }
                }
            }

            if (freshOrangesCount == 0) return timeElapsed;

            int[][] directions = new int[][] {
                new int[] { 0, 1 }, //right
                new int[] { 0, -1 }, //left
                new int[] { 1, 0 }, //down
                new int[] { -1, 0 } //up
            };

            while(q.Count > 0)
            {
                int size = q.Count;
                for(int i = 0; i < size; i++)
                {
                    int[] curr = q.Dequeue();
                    foreach (var dir in directions)
                    {
                        //get the neighboring row and column for all 4 directions
                        int nr = curr[0] + dir[0];
                        int nc = curr[1] + dir[1];

                        //perform bound checks and if it is fresh orange only, then insert to queue and mark the orange as rotten and decrement fresh oranges count.
                        //if fresh oranges count become zero while we are processing the queue, then just return time + 1
                        //since the time is getting incremented after the level is complete only
                        if(nr >= 0 && nr < m && nc >= 0 && nc < n && grid[nr][nc] == 1)
                        {
                            q.Enqueue(new int[] { nr, nc });
                            grid[nr][nc] = 2;
                            freshOrangesCount--;
                            if(freshOrangesCount == 0)
                            {
                                return timeElapsed + 1;
                            }
                        }

                    }
                }
                timeElapsed++;
            }
   
            return -1;
        }
    }
