    static string[,] ToStringArray(object arg)
    {
        string[,] result = null;
    
        if (arg is Array)
        {
            int rank = ((Array)arg).Rank;
            if (rank == 2)
            {
                int columnCount = ((Array)arg).GetUpperBound(0);
                int rowCount = ((Array)arg).GetLength(0);
                result = new string[rowCount, columnCount];
    
                for (int i = 0; i < rowCount; i++)
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        result[i, j] = ((Array)arg).GetValue(i, j).ToString();
                    }
                }
            }
        }
    
        return result;
    }
