    List<List<DataRow>> rowsList = new List<List<DataRow>>();
    ParallelOptions parallelOptions = new ParallelOptions();
    parallelOptions.MaxDegreeOfParallelism = Environment.ProcessorCount;
    Parallel.ForEach(allData, parallelOptions, dataObj =>
    {
        List<DataRow> rows = new List<DataRow>();
        //do processing
        lock(rowsList)
        {
            rowsList.Add(rows);
        }
    });
    DataTable table = createTable();
    foreach (List<DataRow> rows in rowsList)
    {
        foreach (DataRow row in rows)
        {
            table.Rows.Add(row);
        }
    }
