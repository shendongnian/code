    public static class Utils
    {
    	public static List<T[]> To1DArrayList<T>(this T[,] source)
    	{
    		if (source == null) throw new ArgumentNullException("source");
    		int rowCount = source.GetLength(0), colCount = source.GetLength(1);
    		var list = new List<T[]>(rowCount);
    		for (int row = 0; row < rowCount; row++)
    		{
    			var data = new T[colCount];
    			for (int col = 0; col < data.Length; col++)
    				data[col] = source[row, col];
    			list.Add(data);
    		}
    		return list;
    	}
    }
