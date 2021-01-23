    public static void ParallelTest()
    {
    	Parallel.For(0, TOTAL_REQUEST, i =>
    	{
    		string html = GetHtml(i);
    		File.WriteAllText($"SomeFile {i}.txt", html);
    	});
    }
