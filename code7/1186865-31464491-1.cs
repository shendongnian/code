    public static string[,] RemoveEmptyDates(string[,] array)
    {
        // Find how many rows have an empty date
        int rowsToRemove = 0;
        for (int i = 0; i <= array.GetUpperBound(0); i++)
        {
            if (string.IsNullOrEmpty(array[i, 0]))
            {
                rowsToRemove++;
            }
        }
        // Reinitialize an array minus the number of empty date rows
        string[,] results = new string[array.GetUpperBound(0) + 1 - rowsToRemove, array.GetUpperBound(1) + 1];
        int row = 0;
        for (int i = 0; i <= array.GetUpperBound(0); i++)
        {
            int col = 0;
            if (!string.IsNullOrEmpty(array[i, 0]))
            {
                for (int j = 0; j <= array.GetUpperBound(1); j++)
                {
                    results[row, col] = array[i, j];
                    col++;
                }
                row++;
            }
        }
        return results;
    }
