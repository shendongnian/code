    public async Task MyOriginalMethod()
    {
        using (var dbc = new SqlConnection(db.Database.Connection.ConnectionString))
        {
            dbc.Open();
        
            Task<int> task1 = MergeOneDataTableAsync();
            Task<int> task2 = MergeTwoDataTableAsync();
            
            int[] results = await Task.WhenAll(new Task<int>[]{task1,task2});
    
            recordedStatistics.Add("mergeOne", results[0]);
            recordedStatistics.Add("mergeTwo", results[1]);
        }
    
        //...
    }
