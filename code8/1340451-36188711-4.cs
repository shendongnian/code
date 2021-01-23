    ConcurrentBag<object[]> bag = new ConcurrentBag<object[]>();
    Parallel.ForEach(allData, 
        new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, 
        dataObj =>
    {
        object[] row = new object[colCount];
        //do processing
        bag.Add(row);
        Thread.Sleep(100);
    });
    DataTable table = createTable();
    foreach (object[] row in bag)
    {
        table.Rows.Add(row);
    }
