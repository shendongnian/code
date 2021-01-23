    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ParentEnrollment>()
        			.HasRequired(m => m.CellGroup)
        			.WithMany(m => m.Parents)
        			.HasForeignKey(m => m.CellGroupID)
        			.WillCascadeOnDelete(false);
    }
