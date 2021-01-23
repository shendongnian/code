    public static void PrintPyramid(int n)
    {
        PrintPyramidRecursive(n, 1, 1, 1);
    }
    private static void PrintPyramidRecursive(int n, int i = 1, int row = 1, int maxNumberInRow = 1)
    {
        Console.Write(i);
        Console.Write(" ");
        i++;
        if (i > maxNumberInRow)
        {
            Console.WriteLine();
            row++;
            maxNumberInRow += row;
            if (row > n)
            {
                return;
            }
        }
        PrintPyramidRecursive(n, i, row, maxNumberInRow);
    }
