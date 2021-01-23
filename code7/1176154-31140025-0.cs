	private static string TakeIt(string inputString)
	{
		if (!Regex.IsMatch(inputString, "(R0RKE|R10KE|R0HKE)"))
		{
			return string.Empty;
		}
		
		var regex = new Regex(@"_");
		var occurances = regex.Matches(inputString);
		var index = occurances[3].Index + 1;
		return inputString.Substring(index, inputString.Length - index);
	}
	
	void Main()
	{
		var string1 = "m60_CLDdet2_LOSS2CLF_060520469434_R0RKE_52_GU";
		var string2 = "m60_CLDdet2_LOSS2CLF_060520469434_R10KE_52_TCRER";
		var string3 = "m60_CLDdet2_LOSS2CLF_060520469434_R0HKE_52_NT";
		var string4 = "m60_CLDdet2_LOSS2CLF_060520469434_hhhhh";
	
		Console.WriteLine(TakeIt(string1));
		Console.WriteLine(TakeIt(string2));
		Console.WriteLine(TakeIt(string3));
		Console.WriteLine(TakeIt(string4));
	}
