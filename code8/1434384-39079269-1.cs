    static class Program
    {
    	public static void Main()
    	{
    		var input = Console.ReadLine();
    		int intResult;
    		var result = int.TryParse(input, out intResult) ? Either<int, string>.MakeLeft(intResult) : Either<int, string>.MakeRight(input);
    		result.ForEach(r => Console.WriteLine("You passed me the integer one less than " + ++r), r => Console.WriteLine(r));
    	}
    }
