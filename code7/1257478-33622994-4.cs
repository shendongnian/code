	Position[] availableMoves = GetAvailableMoves(board);
	if (availableMoves.Length < 1)
	{
		// no valid moves left, do something about end of game condition here
		return;
	}
	// choose one of the available moves
	Position move = availableMoves.Length < 2 ? availableMoves[0] : availableMoves[rand.Next(0, availableMoves.Length)];
	// put white token in position - change this for green's turn
	board[availableMoves.Row, availableMoves.Column] = 1;
