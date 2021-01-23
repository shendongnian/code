    List<Task> tasks  = new List<Task>();
    while(!parser.EndOfData)
    {
        tasks.Add(WriteTodb(tablename, set)));
    }
    // asynchroniously await all the writes
    await Task.WhenAll(tasks.ToArray());
    public async Task WriteTodb(string table,CellSet set)
    {
        //WriteToDB
        //Edit: This statement will write to hbase db in hdinsight asynchroniously!
        await hbase.StoreCellsAsync(TableName, set);
    }
