    public static class Matrix
    {
        public static TResult[,] Select<T, TResult>(this T[,] source, Func<T, TResult> f)
        {
            var rows = source.GetLength(0);
            var columns = source.GetLength(1);
            var result = new TResult[rows, columns];
            for (var row = 0; row < rows; row++)
            {
                for (var column = 0; column < columns; column++)
                {
                    result[row, column] = f(source[row, column]);
                }
            }
            return result;
        }
    }
