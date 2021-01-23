	private static void SetTextForLine(string text, ref int line)
	{
		//set the status line for future reference
		if (line < 0)
		{
			line = Console.CursorTop;
		}
	
		//save line/cursor state
		int currentLine = Console.CursorTop;
		bool cursorVisible = Console.CursorVisible;
		Console.SetCursorPosition(0, line);
		Console.WriteLine(text);
		
		//restore state
		Console.CursorTop = (currentLine == line ? currentLine + 1 : currentLine);
		Console.CursorVisible = cursorVisible;
	}
