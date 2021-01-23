	void Main()
	{
		var status = MyStatus.ResponseTooBig | MyStatus.NoResponse;
		if (status.Equals(MyStatus.OKResponse))
			Console.WriteLine("Status is OKResponse");
		else 
			Console.WriteLine($"Has NoResponse?: {status.HasFlag(MyStatus.NoResponse)}");
	}
