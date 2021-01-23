    static class MatrixExtensions
    {
        public static IEnumerable<T[,]> ChunkMatrix<T>(this T[,] inputMatrix, int chunkWidth, int chunkHeight)
        {
            int inputWidth = inputMatrix.GetLength(0);
            int inputHeight = inputMatrix.GetLength(1);
            for (int i = 0; i < inputWidth; i += chunkWidth)
            {
                for (int j = 0; j < inputHeight; j += chunkHeight)
                {
                    T[,] chunk = new T[chunkWidth, chunkHeight];
                    for (int k = 0; k < chunkWidth; k++)
                    {
                        int sourceIndex = i*inputWidth + k* inputWidth + j;
                        var destinationIndex = k* chunkHeight;
                        Array.Copy(inputMatrix, sourceIndex, chunk, destinationIndex, chunkHeight);
                    }
                    yield return chunk;
                }
            }
        }
    }
