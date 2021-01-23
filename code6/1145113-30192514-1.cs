    public IList<T> GetList<T>(
            DataTable table,
            Func<DataRow, T> extractor)
    {
        var result = new T[table.Rows.Count];
        for (var i = 0; i < table.Rows.Count; i++)
        {
            result[i] = extractor(table.Rows[i]);
        }
        return result;
    }
