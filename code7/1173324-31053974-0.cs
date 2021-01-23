    static void Main(string[] args)
    {
        WorkingTimer wt = new WorkingTimer();
        wt.Every3Seconds += wt_Every3Seconds;
        wt.Every5Seconds += wt_Every5Seconds;
        Console.ReadLine();
    }
