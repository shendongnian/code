       static T[][] ToJag<T>(T[,] source)
        {
            try
            {
                int FirstDim = source.GetLength(0);  // rows
                int SecondDim = source.GetLength(1); // cols
                var result = new T[FirstDim][];   // only acceptable syntax ???
                for (int i = 0; i < FirstDim; ++i)
                {
                    result[i] = new T[source.GetLength(1)];  // just for columns
                    for (int j = 0; j < SecondDim; ++j)
                    {
                        result[i][j] = source[i, j];
                    }
                }
                return result;
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Invalid operation error.");
            }
        }
        static T[,] To2D<T>(T[][] source)
        {
            try
            {
                int FirstDim = source.Length;
                int SecondDim = source.GroupBy(row => row.Length).Single().Key; // throws InvalidOperationException if source is not rectangular
                var result = new T[FirstDim, SecondDim];
                for (int i = 0; i < FirstDim; ++i)
                    for (int j = 0; j < SecondDim; ++j)
                        result[i, j] = source[i][j];
                return result;
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("The given jagged array is not rectangular.");
            }
        }
