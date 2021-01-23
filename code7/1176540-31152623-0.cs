    static int[,] Matrix(int n)
    {
        if (n < 0)
            throw new ArgumentException("n must be a positive integer.", "n");
        var result = new int[n, n];            
        int counter = 1;
        int level = 0;
        while (level < (int)Math.Ceiling(n / 2f))
        {
            // Start at top left.
            int x = level, y = level;
            // Move from left to right.
            for (; x < n - level; x++)
            {
                result[x, y] = counter++;
            }
            // Move from top to bottom.
            for (y++, x--; y < n - level; y++)
            {
                result[x, y] = counter++;
            }
            // Move from right to left.
            for (x--, y--; x >= level; x--)
            {
                result[x, y] = counter++;
            }
            // Move from bottom to top.
            for (y--, x++; y >= level + 1; y--)
            {
                result[x, y] = counter++;
            }
            // Go to inner level.
            level++;
        }
        return result;
    }
