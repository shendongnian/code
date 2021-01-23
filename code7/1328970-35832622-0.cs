    protected override void OnModelCreating(DbModelBuilder mb)
	{
		mb.Entity<ApplicationUser>()
			.HasMany(au => au.Groups)
			.WithMany(grp => grp.Members)
			.Map(m =>
			{
				m.ToTable("ApplicationUserGroup");
				m.MapLeftKey("ApplicationUserID");
				m.MapRightKey("GroupID");
			});
	}
