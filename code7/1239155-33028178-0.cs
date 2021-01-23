    public MyDbContext(string connectionString)
        : base(connectionString)
    {
        if (!Database.Exists())
        {
            Database.SetInitializer(new CreateInitializer());
        }
        else
        {
            bool isCompatible = false;
            
            isCompatible = Database.CompatibleWithModel(false);
            
            
            if (!isCompatible)
            {
                // Here is where it gets thrown.  
                throw new ExceptionDatabaseVersion("Data structure changed");
            }
        }
    }` 
