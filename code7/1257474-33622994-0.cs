	public static void PrintBoard(int[,] board)
	{
		Console.Clear();
		for (int row = 0; row < board.GetLength(0); row++)
		{
			Console.Write("P{0} |", row);
			for (int col = 0; col < board.GetLength(1); col++)
			{
				// Figure out what is at the current position
				int content = board[row,col];
				char c = content == 1 ? 'W' : content == 2 ? 'G' : ' ';
				Console.Write("{0}|", c);
			}
			Console.WriteLine();
			Console.WriteLine();
		}
	}
