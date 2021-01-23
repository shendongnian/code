    public async Task Refresh_Control(string devicename)
    {
        Task<int> mcResult = 
            Genkai_db.Database.ExecuteSqlCommandAsync("exec Refresh_McAfee @devicename", 
                new SqlParameter("@devicename", devicename));
        Task<int> dcaiResult = 
            Genkai_db.Database.ExecuteSqlCommandAsync("exec Refresh_DCAI @devicename", 
                new SqlParameter("@devicename", devicename));
    
        await Task.WhenAll(mcResult, dcaiResult);
    
        int mc = mcResult.Result;
        int dc = dcaiResult.Result;
    
        Console.WriteLine("Finish Refresh :: mc=" + mc + ", dc=" + dc);
    }
