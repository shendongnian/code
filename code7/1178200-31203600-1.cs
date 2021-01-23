    var items = new ConcurrentDictionary<DataRow, Dictionary<object,object>>;
    Parallel.ForEach(dataTable.AsEnumerable(),row => {
        var result = ...; 
        items.Add(row, result);
    });
    var finalResult = dataTable.Rows.Cast<DataRow>().Select(r => items[r]).ToList());
