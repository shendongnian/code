    interface IMyDbContext
    {
        ...
    
        int CommandTimeout { get; set; }
    }
    
    
    class MyDbContext : IMyDbContext
    {
        ...
    
        public int CommandTimeout
        {
            get { return ObjectContext.CommandTimeout; }
            set { ObjectContext.CommandTimeout = value; }
        }
    }
