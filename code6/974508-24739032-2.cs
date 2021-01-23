    private static void Main(string[] args)
    {
    	Stopwatch t = new Stopwatch();
    	t.Start();
    	int i = 0;
    	for (int j = 0; j < 2000000001; j++)
    	{
    		i++;
    	}
    	t.Stop();
    	Stopwatch t2 = new Stopwatch();
    	t2.Start();
    	int k = 0;
    	for (int l = 0; l < 2000000001; l++)
    	{
    		k++;
    	}
    	t2.Stop();
    	Console.WriteLine(t.Elapsed);
    	Console.WriteLine(t2.Elapsed);
    	Console.ReadLine();
    }
