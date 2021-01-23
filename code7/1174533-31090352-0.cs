    static void Main(string[] args)
	{	
		long decimalNum = long.Parse(Console.ReadLine());
		StringBuilder sb = new StringBuilder();
		Stack<String> BinaryResult = new Stack<string>();
		while (decimalNum > 0)
		{
			var rem = decimalNum%2;
			BinaryResult.Push(rem.ToString());
			decimalNum = decimalNum/2;
		}
			
		while (BinaryResult.Count > 0)
		{
			sb.Append(BinaryResult.Pop().ToString());
		}
		Console.WriteLine(sb.ToString());
		Console.ReadLine();
	}
