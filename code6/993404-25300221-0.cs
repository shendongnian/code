    void Main()
    {
	var TargetNumber = 2000;
	var TestRuns = 10;
	//warmup both methods
	calculate(100);
	TestIterative(100);
	
	Stopwatch sw = new Stopwatch();
	
	var RecursiveTimes = new List<long>();
	
	for(int run = 1;run<=TestRuns;run++)
	{
		sw.Restart();
		for (int i = 1; i <= TargetNumber; i++)
		{
			calculate(i);
		}
		sw.Stop();
		RecursiveTimes.Add(sw.ElapsedMilliseconds);
	}
	
	var IterativeTimes = new List<long>();
	
	for(int run = 1;run<=TestRuns;run++)
	{
		sw.Restart();
		for (int  i = 1; i <= TargetNumber; i++)
		{
			TestIterative(i);
		}
		sw.Stop();
		IterativeTimes.Add(sw.ElapsedMilliseconds);
	}
	
	Console.WriteLine("Iterative : " + IterativeTimes.Average() + " ms on average. Min and max : " + IterativeTimes.Min() + " / " + IterativeTimes.Max());
	Console.WriteLine("Recursive : " + RecursiveTimes.Average() + " ms on average. Min and max : " + RecursiveTimes.Min() + " / " + RecursiveTimes.Max());	
    }
    static long TestIterative(long x)
    {
    	long retVal = 0;
    	for (long y = 1; y <= x; y++)
    	{ 
    		retVal += y;
    	}
    	return retVal;
    }
    static long calculate(long x)
    {
    	if (x <= 1)
    		return x;
    	else
    		return x + calculate(x - 1);
    }
