	async Task<int> UsesStatic(int defaultValue) 
	{
		static int bar;
		try
		{
			throw new Exception("Boom!");
		}
		catch
		{
			using(var errorLogger = Log.NewLogger("init failed")
			{
				// here's the awaited call;
				bar = await service.LongRunningCall(() => Math.Abs(defaultValue));
				// that'll fail; 
				throw new Exception("Oh FFS!");
			}
		}
		finally
		{
		    bar = 0;
		}
	}
