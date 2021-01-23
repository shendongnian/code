    public static bool SearchArray(int soughtOutNum, int [,] searchableArray, out int rowIndex, out int colsIndex)
    {
        if(searchableArray.Any(x => soughtOutNum))
        {
            colsIndex = searchableArray.FirstOrDefault(x => x == soughtOutNum).GetLength(0);
            rowIndex= searchableArray.FirstOrDefault(x => x == soughtOutNum).GetLength(1);
        }
        else
        {
            return false;
        }        
    }
