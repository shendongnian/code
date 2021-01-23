    using (var dbc = new SqlConnection(db.Database.Connection.ConnectionString))
    {
        dbc.Open();
    
        Task<int> task1 = MergeOneDataTableAsync();
        Task<int> task2 = MergeTwoDataTableAsync();
        
        Task.WaitAll(new Task[]{task1,task2}); //synchronously wait
        recordedStatistics.Add("mergeOne", task1.Result);
        recordedStatistics.Add("mergeTwo", task2.Result);
    }
