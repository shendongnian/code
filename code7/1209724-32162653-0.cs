    public static class MyExtensions
    {
        public static void Initialize<T>(this T[,] board) where T : new()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i,j] = new T();
                }
            }
        }
    }
