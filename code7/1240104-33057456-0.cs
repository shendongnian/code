    static void Main(string[] args)
    {
        StringBuilder sb = new StringBuilder();
        Random random = new Random();
        int[,] array = new int[10, 2];
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = random.Next(10);
                if (j > 0)
                {
                    sb.Append(", ");
                }
                sb.Append(array[i, j]);
            }
            sb.AppendLine();
        }
        Console.WriteLine(sb);
    }
