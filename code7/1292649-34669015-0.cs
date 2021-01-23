    public static void ParallelTest()
    {
    	List<string> results = new List<string>();
    	Parallel.For(0, TOTAL_REQUEST, i =>
    	{
    		string html = GetHtml(i);
    		lock(results)
    			results.Add(html);
    	});
    }
