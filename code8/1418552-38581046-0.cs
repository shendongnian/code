	string letters = $"This would be the {string}."
	string ColoredLetters = {string}; // Whatever is your string
	Char[] array = letters.ToCharArray();
	void WriteLineWithColoredLetter(string letters, char c) 
	{
		var NormalWrite = letters.IndexOf(c);
		Console.Write(letters.Substring(0, NormalWrite));
		Console.ForegroundColor = ConsoleColor.Red;
		Console.Write(ColoredLetters);
		Console.ResetColor();
		Console.WriteLine(letters.Substring(NormalWrite + 1));
	}
