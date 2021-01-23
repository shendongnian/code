    public static void Main()
    {
        int[,] array = { { 1, 2 }, { 3, 4 }, { 5, 6 } };
        StringBuilder sb = new StringBuilder();
        for (int x = 0; x < array.GetLength(0); x++)
        {
            for (int y = 0; y < array.GetLength(1); y++)
            {
                sb.Append(array[x, y] + " ");
            }
            sb.Append(Environment.NewLine);
        }
        Console.Write(sb);
        Console.ReadLine();
    }
