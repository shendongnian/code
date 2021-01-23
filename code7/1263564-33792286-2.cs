    static void Main()
    {
        Random rand = new Random();
        int[,] arr = new int[3,3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                arr[i, j] = rand.Next(0, 100);
            }
        }
        int[,] newarr = CountingSort2D(arr);
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            Console.Write("{ ");
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write(arr[i, j] + " ,");
            }
            Console.Write("} ,");
        }
        Console.WriteLine();
        for (int i = 0; i < newarr.GetLength(0); i++)
        {
            Console.Write("{ ");
            for (int j = 0; j < newarr.GetLength(1); j++)
            {
                Console.Write(newarr[i, j] + " ,");
            }
            Console.Write("} ,");
        }
        Console.WriteLine();
    }
