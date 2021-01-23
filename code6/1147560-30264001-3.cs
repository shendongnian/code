    List<DataTable> dataTables = new List<DataTable>();
    
    Parallel.ForEach(newEntries.AsEnumerable(), new ParallelOptions { MaxDegreeOfParallelism = 2 }, row => {
       var request = RunRequest(row);
       lock(dataTables)
       {
            dataTables.Add(request);
       }
    });
