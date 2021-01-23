    public async static Task AsynchronousTest()
    {
    	for (int i = 0; i < TOTAL_REQUEST; i++)
    	{
    		var result = await GetHtmlAsync(i);
    		File.WriteAllText($"SomeFile {i}.txt", result);
    	}
    }
