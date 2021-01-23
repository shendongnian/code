    var result = GetData(new[] { "MyTable1", "MyTable2" });
    if(result.MissingTables.Count > 0)
    {
        Trace.WriteLine("Missing tables: " + string.Join(", ", result.MissingTables));
    }
    // do something with result.DataSet
