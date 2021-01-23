    private static void Main()
    {
        var T1 = new char[,] // more rows than columns
            {
                {'a', 'b', 'd'},
                {'c', 'e', 'g'},
                {'f', 'h', 'j'},
                {'i', 'k', 'l'},
            };
        var T2 = new int[,] // more columns than rows
            {
                {1, 2, 4, 7},
                {3, 5, 8, 0},
                {6, 9, 1, 2},
            };
        Print(T1.GetSecondaryDiagonals());
        Print(T2.GetSecondaryDiagonals());
        Console.ReadKey();
    }
    static void Print<T> (IList<IList<T>> list)
    {
        Console.WriteLine();
        foreach (var sublist in list)
        {
            foreach (var item in sublist)
            {
                Console.Write(item);
                Console.Write(' ');
            }
            Console.WriteLine();
        }
    }
