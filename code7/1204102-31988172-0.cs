    public static void PrintPyramid(int n)
    {
        int t = 1;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                Console.Write(t);
                t++;
            }
            Console.WriteLine();
        }
    }
