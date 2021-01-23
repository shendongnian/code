     int size = 5;
        int[,] matrix = new int[,] {
            {131,673,234,103,18},
            {201,96,342,965,150},
            {630,803,746,422,111},
            {537,699,497,121,956},
            {805,732,524,37,331}
        };
        //Random rand = new Random();
        //for (int y = 0; y < size; ++y)
        //{
        //    for (int x = 0; x < size; ++x)
        //    {
        //        matrix[y, x] = rand.Next(10);
        //    }
        //}
        int[,] distance = new int[size, size];
        distance[0, 0] = matrix[0, 0];
        for (int i = 1; i < size * 2 - 1; ++i)
        {
            int y = Math.Min(i, size - 1);
            int x = i - y;
            while (x < size && y >= 0)
            {
                distance[y, x] = Math.Min(
                    x > 0 ? distance[y, x - 1] + matrix[y, x] : int.MaxValue,
                    y > 0 ? distance[y - 1, x] + matrix[y, x] : int.MaxValue);
                x++;
                y--;
            }
        }
        for (int y = 0; y < size; ++y)
        {
            for (int x = 0; x < size; ++x)
            {
                Console.Write(matrix[y, x].ToString().PadLeft(5, ' '));
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        for (int y = 0; y < size; ++y)
        {
            for (int x = 0; x < size; ++x)
            {
                Console.Write(distance[y, x].ToString().PadLeft(5, ' '));
            }
            Console.WriteLine();
        }
        Console.WriteLine();
