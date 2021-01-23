    public ContextA(): base("name=ConnectionString")
    {
                
    }
    
    public ContextA(DbConnection connection) : base(connection, false)
    {
    
    }
