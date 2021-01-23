	public static void Main()
	{
		var numbers = new Stack<int>();
		numbers.Push(4);
		numbers.Push(1);
		numbers.Push(2);
		
		var numbersSorted = numbers.OrderBy(num => num).ToArray();
		Console.WriteLine(string.Join(", ", numbersSorted));
	}
	
