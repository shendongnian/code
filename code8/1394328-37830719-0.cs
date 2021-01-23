    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LocationIssueModel>().ToTable("LocationIssues");
        modelBuilder.Entity<PersonIssueModel>().ToTable("PersonIssues");
    }
