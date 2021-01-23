    public T[,] Combine<T>(T[,][,] m)
    {
        // get the rows
        var rows = GetSliceRows(m);
        var rows_result = rows.Sum();
        
        // get the cols
        var cols = GetSliceCols(m);
        var cols_result = cols.Sum();
        
        // get the offsets
        var offsets = GetOffsets(rows, cols);
        
        // fill 'er up
        var result = new T[rows_result, cols_result];
        Fill(result, m, offsets);
        return result;
    }
    
    public int[] GetSliceRows<T>(T[,][,] m)
    {
        var sliceRows = new int[m.GetLength(0)];
        var segments = m.GetLength(1);
        for (var i = 0; i < sliceRows.Length; i++)
        {
            sliceRows[i] = Enumerable.Range(0, segments)
                .Select(j => m[i, j].GetLength(0))
                .Max();
        }
        return sliceRows;
    }
    
    public int[] GetSliceCols<T>(T[,][,] m)
    {
        var sliceCols = new int[m.GetLength(1)];
        var segments = m.GetLength(0);
        for (var j = 0; j < sliceCols.Length; j++)
        {
            sliceCols[j] = Enumerable.Range(0, segments)
                .Select(i => m[i, j].GetLength(1))
                .Max();
        }
        return sliceCols;
    }
    
    public Tuple<int, int>[,] GetOffsets(int[] rows, int[] cols)
    {
        var offsets = new Tuple<int, int>[rows.Length, cols.Length];
        for (var i = 0; i < rows.Length; i++)
            for (var j = 0; j < cols.Length; j++)
                offsets[i, j] = Tuple.Create(
                    rows.Take(i).Sum(),
                    cols.Take(j).Sum()
                );
        return offsets.Dump();
    }
    
    public void Fill<T>(T[,] result, T[,][,] m, Tuple<int, int>[,] offsets)
    {
        for (var i = 0; i < m.GetLength(0); i++)
            for (var j = 0; j < m.GetLength(1); j++)
                Fill(result, m[i, j], offsets[i, j]);
    }
    
    public void Fill<T>(T[,] result, T[,] source, Tuple<int, int> offset)
    {
        for (var i = 0; i < source.GetLength(0); i++)
            for (var j = 0; j < source.GetLength(1); j++)
                result[offset.Item1 + i, offset.Item2 + j] = source[i, j];
    }
