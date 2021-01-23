     public int Test9(int[,] matrix)
        {
           int zeroCounter = 0;
           for (int i = 0; i < matrix.GetLength(0); i++)
        	for (int j = 0; j < matrix.GetLength(1); j++)
        	{
        			if(matrix[i, j] == 0)
        			{
        				zeroCounter++;
        			}
        	}
        }
