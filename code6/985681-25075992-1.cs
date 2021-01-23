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
            get { return ((IObjectContextAdapter)this).ObjectContext.CommandTimeout; }
            set { ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = value; }
        }
    }
