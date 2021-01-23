    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PrmEBD>().ToTable("PrmEBDs");
        modelBuilder.Entity<LoanEBD>().ToTable("LoanEBD");
        modelBuilder.Entity<MaliOp>().ToTable("MaliOp");
    }
