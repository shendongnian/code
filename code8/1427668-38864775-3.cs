    private static double lastResult;
    // lastResult is used so that calculation within methods is not optimized away
 
    public static void CalSize(Creator c)
    {
        lastResult = c(10.0); 
    }
    public static void CalSize2(Func<double, double> f)
    {
        lastResult = f(10.0);
    }
    static void Main()
    {
        Func<double, double> funcCreator = x => Math.Pow(x, 20);
        Stopwatch sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < 10000000; i++)
        {
            // measured code goes here
        }
 
        sw.Stop();
    }
