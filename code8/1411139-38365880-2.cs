	void Main()
	{
		int version = 0;
			
		//numbers.OnNext(1);
		ProcessEven(1, ref version);
		ProcessNumber(1, ref version);
		//numbers.OnNext(2);
		ProcessEven(2, ref version);
		ProcessNumber(2, ref version);
		//numbers.OnNext(3);
		ProcessEven(3, ref version);
		ProcessNumber(3, ref version);
	}
	
	// Define other methods and classes here
	private void ProcessEven(int i, ref int version)
	{
		var isEven = i % 2 == 0;
		var temp = new { IsEven = isEven, Version = Interlocked.Increment(ref version) };
		Console.WriteLine($"Time {temp.Version} : {temp.IsEven}");
	}
	private void ProcessNumber(int i, ref int version)
	{
		var temp = new { Number = i, Version = Interlocked.Increment(ref version) };
		Console.WriteLine($"Time {temp.Version} : {temp.Number}");
	}
