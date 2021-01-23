    /// <summary>
        /// Returns the largest number in the array.
        /// </summary>
        /// <param name="randomArray">The array to search.</param>
        /// <param name="rows">The amount of rows in the array.</param>
        /// <param name="columns">The amount of columns in the array.</param>
        /// <param name="maxX">The x-position (column) of the largest number in the array.</param>
        /// <param name="maxY">The y-position (row) of the largest number in the array.</param>
        /// <returns></returns>
        static int GetLargestNumber(ref int[,] randomArray, int rows, int columns, out int maxX, out int maxY)
        {
            int max;
            maxX = -1;
            maxY = -1;
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    if (randomArray[x, y] > max)
                    {
                        max = randomArray[x, y];
                        maxX = x;
                        maxY = y;
                    }
                }
            }
            return max;
        }
