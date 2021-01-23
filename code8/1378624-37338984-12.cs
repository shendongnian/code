	private static decimal GetParsedInput(string question, string noticeOnFailed)
	{
		Console.Write(question); 
		input = Console.ReadLine();
		decimal result;
		while (!decimal.TryParse(input, out result))
		{
			Console.WriteLine(questionOnFailed);
			input = Console.ReadLine();
		}
		
		return result;
	}
