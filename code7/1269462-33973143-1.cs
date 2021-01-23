    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>()
                        .HasMany(c => c.Contacts)
                        .WithRequired(co => co.Company)
                        .HasForeignKey(co => co.CompanyId);
    }
