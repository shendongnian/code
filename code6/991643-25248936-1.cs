    public static int[,] CreateArray(int numberOfRows, int numberOfCols)
        {
            int[,] map = new int[numberOfRows, numberOfCols];
            Random rnd = new Random();
            for (int i = 0; i < numberOfRows; ++i)
            {
                for (int j = 0; j < numberOfCols; ++j)
                {
                    map[i, j] = rnd.Next(0, 2);
                }
            }
            return map;
        }
