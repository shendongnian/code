	private static void WriteConsolePadded(string value, int length, char padValue)
	{
		Console.Write(value);
		if (Console.CursorLeft < length)
		{
			Console.Write(new string(padValue, length - Console.CursorLeft));
		}
		Console.WriteLine();
	}
