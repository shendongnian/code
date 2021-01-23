    void Main()
    {
        double[] avg = new double[512];
        int start = System.Environment.TickCount;
    
        for (int i = 0; i < 200000; i++)
        {
            double di = (double)i;
            double r = 1/(di + 1);
            for (int j = 0; j < avg.Length; j++)
            {
                // The `i` in `i-avg[j]` is a dummy for the measured variable.
                avg[j] = avg[j] + (di - avg[j]) * r;
            }
        }
    
        Console.WriteLine(System.Environment.TickCount-start);
    }
