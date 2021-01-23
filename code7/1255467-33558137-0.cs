	int playerX;
	int playerY;
	string map;
	public void Draw()
	{
		Console.Clear();
		Console.Write(map);
		// save cursor position
		int l = Console.CursorLeft;
		int t = Console.CursorTop;
		// display player marker
		Console.SetCursorPosition(playerX, playerY);
		Console.Write("@");
		// restore cursor position
		Console.SetCursorPosition(l, t);
	}
