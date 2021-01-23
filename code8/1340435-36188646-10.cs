    IEnumerable<FinalObject> bag = allData
        .AsParallel()
        .WithDegreeOfParallelism(Environment.ProcessorCount)
        .Select(dataObj =>
        {
            FinalObject theData = Process(dataObj);
            Thread.Sleep(100);
            return theData;
        });
    DataTable table = createTable();
    foreach (FinalObject moveObj in bag)
    {
        table.Rows.Add(moveObj.x);
    }
