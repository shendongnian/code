    public void Example()
    {
        var myEfModel = GetEFData();
        object[][] result = ConvertToArrayFormat(myEfModel, row => new object[] {row.Column1, row.Column2, row.Column3}, new object[] {"Column1", "Column2", "Column3"});
    }
    public object[][] ConvertToArrayFormat<T>(IEnumerable<T> dataSource, Func<T, object[]> rowSelector, object[] header = null)
    {
        var result = new List<object[]>();
        if(header != null)
            result.Add(header);
        foreach (var item in dataSource)
        {
            var row = rowSelector(item);
            result.Add(row);
        }
        return result.ToArray();
    }
