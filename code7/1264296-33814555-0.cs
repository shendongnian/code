    public int doMenu()
	{
		int selection = 0;
		ConsoleKeyInfo consoleKeyInfo;
		do
		{
			dispMenu(selection);
			while (!Console.KeyAvailable)
			{
			}
			consoleKeyInfo = Console.ReadKey();
			if (consoleKeyInfo.Key == ConsoleKey.UpArrow)
			{
				if (selection == 0) { selection = elements.Length; }
				else { selection--; }
			}
			else if (consoleKeyInfo.Key == ConsoleKey.DownArrow)
			{
				if (selection == elements.Length) { selection = 0; }
				else { selection++; }
			}
		} while (consoleKeyInfo.Key != ConsoleKey.Enter);
		return selection;
	}
