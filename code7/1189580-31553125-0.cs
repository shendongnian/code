    /// <summary>
    /// Method to draw a line of characters
    /// </summary>
    /// <param name="n">number of characters to draw</param>
    /// <param name="s">character to draw n times</param>
    static void DrawChars(int n, string s)
    {
        for (int row = 1; row <= n; row++)
        {
            for (int col = 1; col <= n; col++)
            {
                Console.Write(col == row ? col.ToString() : s);
            }
            Console.WriteLine();
        }
    }
