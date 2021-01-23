    string str = Console.ReadLine();
    sum = SumOf(str);
	public static int SumOf(string s) 
	{
		int sum = 0;
		foreach (char num in s.ToCharArray())
		{
			sum += (int)char.GetNumericValue(num);
		}
		return sum;
	}
