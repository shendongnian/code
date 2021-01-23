    public static T[,] To2DArray<T>(this IEnumerable<T> source, int rows, int columns)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        if (rows < 0 || columns < 0)
            throw new ArgumentException("rows and columns must be positive integers.");
        var result = new T[rows, columns];
        if (columns == 0 || rows == 0)
            return result;            
        int column = 0, row = 0;
        foreach (T element in source)
        {
            if (column >= columns)
            {
                column = 0;                    
                if (++row >= rows)                    
                    throw new InvalidOperationException("Sequence elements do not fit the array.");                         
            }
            result[row, column++] = element;                
        }
        return result;
    }
