    public int[][] MakeGrid()
    {
        grid  = new int[4][];
        for (int i = 0; i < 4; i++)
        {
            grid[i] = new int[4] { 0, 0, 0, 0 };
            for (int a = 0; a < 4; a++)
            {
                Console.Write(grid[i][a]);
            }
            Console.WriteLine();
        }
        return grid;
    }
