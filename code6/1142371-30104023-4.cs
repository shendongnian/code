    public static string[,] RemoveEmptyRows2(string[,] strs)
    {
        int length1 = strs.GetLength(0);
        int length2 = strs.GetLength(1);
        // First we put somewhere a list of the indexes of the non-emtpy rows
        var nonEmpty = new List<int>();
        for (int i = 0; i < length1; i++)
        {
            int j = 0;
            for (; j < length2; j++)
            {
                if (strs[i, j] != null)
                {
                    break;
                }
            }
            if (j < length2)
            {
                nonEmpty.Add(i);
            }
        }
        // Then we create an array of the right size
        string[,] strs2 = new string[nonEmpty.Count, length2];
        // And we copy the rows from strs to strs2, using the nonEmpty
        // list of indexes
        for (int i1 = 0; i1 < nonEmpty.Count; i1++)
        {
            int i2 = nonEmpty[i1];
            for (int j = 0; j < length2; j++)
            {
                strs2[i1, j] = strs[i2, j];
            }
        }
        return strs2;
    }
