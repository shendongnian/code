    // Calculate the needed number of rows
    int nRows = (int)Math.Pow(symbols.Length, nCols);
    // Allocate memory for the matrix
    int[,] matrix = new int[nRows, nCols];
    // The first column repeats elements exactly once
    int repeatedElementsInCol = 1;
    //Successively fill all columns
    for (int col = 0; col < nCols; ++col)
    {
        int row = 0;
        // Fill every row
        while(row < nRows)
        {
            // Write each symbol to the matrix ...
            foreach (var symbol in symbols)
                // ... with the specified number of repetitions
                for (int repetition = 0; repetition < repeatedElementsInCol; ++repetition)
                    matrix[row++, col] = symbol;
        }
    
        // The next column repeats elements symbols.Length times as often
        repeatedElementsInCol *= symbols.Length;
    }
