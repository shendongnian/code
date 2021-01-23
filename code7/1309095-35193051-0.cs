    public int score(char color)
    {
        int adj = 0;
        int score = 0;
        for (int i = 0; i < gameBoard.Length; i++)
        {
            if (gameBoard[i] == color)
            {
                adj++;
            }
            else
            {
                if (adj > 1)
                {
                    score += adj * 2;
                }
                adj = 0;
            }
        }
    }
