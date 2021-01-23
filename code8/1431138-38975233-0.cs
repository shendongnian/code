	// Let Entity Framework to load metadata, generate views and etc.
	using (TestContext context = new TestContext())
	{                
		var query = context.Set<Message>().AsNoTracking();
		Message first = context
			.Set<Message>()
			.AsNoTracking()
			.FirstOrDefault();
	}
	// Execute warm query
	using (TestContext context = new TestContext())
	{
		// Log the queries to be able to subtract query execution time.
		context.Database.Log = Console.WriteLine;
		var query = context.Set<Message>().AsNoTracking();
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Restart();
		Message first = query.FirstOrDefault();
		stopwatch.Stop();
		Console.WriteLine("Elapsed {0} milliseconds.", stopwatch.ElapsedMilliseconds);
	}
	
