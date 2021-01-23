	protected override void OnModelCreating( DbModelBuilder modelBuilder )
	{
		base.OnModelCreating( modelBuilder );
		modelBuilder.Entity<Contract>()
			.HasRequired( c => c.Site)
			.WithMany( s => s.Contracts )
			.WillCascadeOnDelete( false );
    }
