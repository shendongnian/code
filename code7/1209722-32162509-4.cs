       public TField[,] InitializeArray<TField>(
          int BoardHeight, int BoardWidth) where TField:new()
       {
    		var Board = new TField[BoardHeight, BoardWidth];
    	
    		for (int i = 0; i < BoardHeight; i++)
    		{
    			for (int j = 0; j < BoardWidth; j++)
    			{
    				Board[i, j] = new TField();
    			}
    		}
    		return Board;
    }
