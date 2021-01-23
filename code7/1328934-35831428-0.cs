    int rowCount = numbers.GetLength(0) - 1; // # rows, exc. total
    int columnCount = numbers.GetLength(1) - 1; // # cols, exc. total
    for (row = 0; row < rowCount; row++)
    {
        for (column = 0; column < columnCount; column++)
        {
            int cell = numbers[row, column];
            checked // throw on arithmetic overflow
            {
                 numbers[row, columnCount] += cell;
                 numbers[rowCount, column] += cell;
                 numbers[rowCount, columnCount] += cell;   
            }
        }
    }
