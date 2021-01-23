	Console.WriteLine(Convert.ToInt32('　')); // output: 12288
	Console.WriteLine(Convert.ToInt32(' ')); // output: 32
	string input1 = "abc  dfg";
	string input2 = "尾え　れ"; // a space
	string input3 = "尾え れ"; // not a space
	if (input1.Contains(" "))
	{
		Console.WriteLine(input1.Replace(" ", "_"));
	}
	Console.WriteLine("------------------");
	if (input2.Contains("　"))
	{
		Console.WriteLine(input2.Replace("　", "_"));
	}
	Console.WriteLine("------------------");
	if (input3.Contains(" "))
	{
		Console.WriteLine(input3.Replace(" ", "_"));
	}
