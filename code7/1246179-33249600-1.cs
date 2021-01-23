    // this does not require .NET 4.6
	DateTime now = DateTime.Now;
	string s = $"Hour is {now.Hour}";
	Console.WriteLine(s);
    //Output: Hour is 13
	
    // this requires >= .NET 4.6
	FormattableString fs = $"Hour is {now.Hour}";
	Console.WriteLine(fs.Format);
	Console.WriteLine(fs.GetArgument(0));
    //Output: Hour is {0}
    //13
