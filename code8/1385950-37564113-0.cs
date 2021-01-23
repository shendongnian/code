    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {    
        modelBuilder.HasDefaultSchema("MAIN");
    
        base.OnModelCreating(modelBuilder);
        // changes for identity entities here
    }
