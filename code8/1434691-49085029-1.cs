    public DbContext() 
        :base()
    {
       var a = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
    }
