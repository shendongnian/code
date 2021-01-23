    public static void PrintPyramid(int n)
    {
        int i = 1;
        int row = 1;
        int maxNumberInRow = 1;
        int cycles = 0;
        while (row <= n)
        {
            cycles++;
            if (i == maxNumberInRow)
            {
                Console.Write(i);
                Console.Write(" ");
                i++;
            }
            else
            {
                Console.Write(i);
                Console.Write(" ");
                i++;
                Console.Write(i);
                Console.Write(" ");
                i++;
            }
            if (i > maxNumberInRow)
            {
                Console.WriteLine();
                row++;
                maxNumberInRow += row;
            }
        }
        Console.WriteLine();
        Console.WriteLine("Cycles: {0}", cycles);
    }
