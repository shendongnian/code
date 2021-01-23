	public static bool IsMoveValid(int[,] board, int row, int col)
	{
		if (row < 0 || row >= board.GetLength(0))
			return false;
		if (col < 0 || col >= board.GetLength(1))
			return false;
		return board[row,col] == 0;
	}
