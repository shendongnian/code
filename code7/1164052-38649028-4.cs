	IQueryable<int> query = Test().AsQueryable();
	Console.WriteLine("Before Freeze");
	Func<List<int>> frozen = query.Freeze(t => t > 10, t => t);
	Console.WriteLine("After Freeze");
	
	Console.WriteLine("Before Invokes");
	List<int> results1 = frozen.Invoke();
	List<int> results2 = frozen.Invoke();
	Console.WriteLine("After Invokes");
