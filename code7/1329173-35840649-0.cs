	void Main()
	{
		var status = MyStatus.ResponseTooBig;
		Console.WriteLine(status.HasFlag(MyStatus.OKResponse));
	}
