    if (Enum.IsDefined(typeof(MyStatus), (int)_status))
	{
		var status = (MyStatus)_status;
		Console.WriteLine(status);
	}
	else 
	{
		Console.WriteLine("Not a valid value.");
	}
