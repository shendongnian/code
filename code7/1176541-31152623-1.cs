    static int[,] Matrix(int n)
    {
        if (n < 0)
            throw new ArgumentException("n must be a positive integer.", "n");
        var result = new int[n, n];                    
        int level = 0,
            counter = 1;
        while (level < (int)Math.Ceiling(n / 2f))
        {
            // Start at top left of this level.
            int x = level, 
                y = level;
            // Move from left to right.
            for (; x < n - level; x++)
            {
                result[y, x] = counter++;
            }
            // Move from top to bottom.
            for (y++, x--; y < n - level; y++)
            {
                result[y, x] = counter++;
            }
            // Move from right to left.
            for (x--, y--; x >= level; x--)
            {
                result[y, x] = counter++;
            }
            // Move from bottom to top. Do not overwrite top left cell.
            for (y--, x++; y >= level + 1; y--)
            {
                result[y, x] = counter++;
            }
            // Go to inner level.
            level++;
        }
        return result;
    }
