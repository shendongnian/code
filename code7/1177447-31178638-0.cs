    public static class ArrayExtensions
    {
        public static TResult[,] ConvertAll<TSource, TResult>(this TSource[,] source, Func<TSource, TResult> projection)
        {
            var result = new TResult[source.GetLength(0), source.GetLength(1)];
            for (int x = 0; x < source.GetLength(0); x++)
                for (int y = 0; y < source.GetLength(1); y++)
                    result[x, y] = projection(source[x, y]);
            return result;
        }
    }
