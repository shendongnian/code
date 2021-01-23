    const int numRows = 3;
    const int numColumns = 4;
    
    double[,] initialArray = new double[numRows, numColumns] { { 5, 1, 9, 3 }, { 7, 8, 6, 4 }, { 2, 4, 9, 5 } };
    double[] rowTotal = new double[numRows];
    
    for (int i = 0; i < numRows; i++)
    {
        for (int j = 0; j < numColumns; j++)
        {
            rowTotal[i] += initialArray[i, j];
        }
        Console.WriteLine("Current row total: {0}", rowTotal[i]);
    }
