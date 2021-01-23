    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Contract>().HasOptional(c => c.ContractParent).WithMany(c => c.Contracts).HasForeignKey(c => c.ContractParentId);
      base.OnModelCreating(modelBuilder);
    }
