    using (var context = new EasyContext ())
	{
		// Uncomment this line to see the raw sql commands
		//context.Database.Log = Console.WriteLine;
		context.Database.CreateIfNotExists();
		context.Database.Initialize(true);
	}
