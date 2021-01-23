    for (int row = 0; row < boardSize; row++) //calculating score
	{
		for (int col = 0; col < boardSize; col++)
		{
			char c = board[row, col];
			if (oddOrEven % 2 == 0)
			{
				if (char.IsLetterOrDigit(c))
				{
					if (char.IsUpper(c))
					{
						whiteScore += c;
					}
					else
					{
						blackScore += c;
					}
					Console.WriteLine(c);
				}
			}
			else
			{
				if (char.IsLetterOrDigit(c))
				{
					if (char.IsUpper(c))
					{
						blackScore += c;
					}
					else
					{
						whiteScore += c;
					}
					Console.WriteLine(c);
				}
			}
			oddOrEven++;
		}
	}
