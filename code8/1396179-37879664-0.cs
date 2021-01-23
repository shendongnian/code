    private static void Main(string[] args)
        {
            var arr = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            var sb = new StringBuilder();
            for (int x = 0; x < arr.GetLength(0); x += 1)
            {
                for (int y = 0; y < arr.GetLength(1); y += 1)
                {
                    sb.Append(arr[x, y]).Append(" ");
                }
                sb.AppendLine();
            }
            Console.Write(sb.ToString());
            Console.Read();
        }
