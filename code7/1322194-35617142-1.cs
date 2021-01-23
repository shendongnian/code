    void RandomizeArray(ref int[,] iArray)
        {
            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLS; col++)
                {
                    Random rand = new Random();
                    tictactoeArray[row, col] = rand.Next(2);
                }
            }
        }
