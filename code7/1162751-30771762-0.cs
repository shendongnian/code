    var obs = Observable.Range(0,10)
	                    .Buffer(4)
						.Subscribe(x =>
	{
		Console.WriteLine("Sending data...");
		
		// Simulate sending all data in x
		foreach (var element in x)
		{
			Console.WriteLine(element);
		}
	});
