    public static void PrintPyramid3(int n)
    {
        if (n >= 1)
        {
            Console.Write("1");
            Console.Write(" ");
            Console.WriteLine();
        }
        int i = 2;
        int row = 2;
        int maxNumberInRow = 3;
        int cycles = 0;
        while (row <= n)
        {
            cycles++;
            Console.Write(i);
            i++;
            
            if (i > maxNumberInRow)
            {
                Console.WriteLine();
                row++;
                maxNumberInRow += row;
            }
            else
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();
        Console.WriteLine("Cycles: {0}", cycles);
    }
