    public static void PrintPyramid5(int n)
    {
        int i = 1;
        int row = 1;
        int maxNumberInRow = 1;
        ManualResetEvent mre = new ManualResetEvent(false);
        Timer t = null;
        TimerCallback tc = x =>
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
                    t.Dispose();
                    mre.Set();
                }
            }
        };
        t = new Timer(tc, null, 0, 1);
        mre.WaitOne();
    }
