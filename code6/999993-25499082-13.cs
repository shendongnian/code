	private static void SetStatusLineValue(int value)
	{
		Console.SetCursorPosition(0, Console.CursorTop);
		Console.Write("\rStatus {0} Copied", value);
	}
