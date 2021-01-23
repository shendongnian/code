    public static IList<IList<T>> GetSecondaryDiagonals<T>(this T[,] array2d)
    {
        int rows = array2d.GetLength(0);
        int columns = array2d.GetLength(1);
        var result = new List<IList<T>>();            
        // number of secondary diagonals
        int d = rows + columns - 1;
        int r, c;
        
        // go through each diagonal
        for (int i = 0; i < d; i++)
        {
            // row to start
            if (i < columns)
                r = 0;
            else
                r = i - columns + 1;
            // column to start
            if (i < columns)
                c = i;
            else
                c = columns - 1;
            // items from diagonal
            var diagonalItems = new List<T>();
            do
            {
                diagonalItems.Add(array2d[r, c]);
                r++;
                c--;
            } 
            while (r < rows && c >= 0);
            result.Add(diagonalItems);
        }
        return result;
    }
