    using Tortuga.Chain;
    
    static SqlServerDataSource s_Data = new SqlServerDataSource(DataConnectionString);
    
    public async Task<IList<AsyncFileProcessingQueue>> GetAsyncFileProcessingQueue()
    {
       return s_Data.From("YOUR_TABLE").ToCollection<AsyncFileProcessingQueue>().ExecuteAsync();
    }
