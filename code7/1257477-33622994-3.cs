	public static Position[] GetAvailableMoves(int[,] board)
	{
		List<Position> results = new List<Position>();
		for (int row = 0; row < board.GetLength(0); row++)
		{
			for (int col = 0; col < board.GetLength(1); col++)
			{
				if (board[row,col] == 0)
					results.Add(new Position { Row = row, Column = col });
			}
		}
		return results.ToArray();
	}
