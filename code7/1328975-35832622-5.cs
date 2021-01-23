    protected override void OnModelCreating(DbModelBuilder mb)
	{
		mb.Entity<ApplicationUser>()
				.HasMany(au => au.UserGroups)
				.WithRequired(ug => ug.ApplicationUser)
				.HasForeignKey(ug => ug.ApplicationUserId)
				.WillCascadeOnDelete(false);
		mb.Entity<Group>()
				.HasMany(grp => grp.UserGroups)
				.WithRequired(ug => ug.Group)
				.HasForeignKey(ug => ug.GroupId)
				.WillCascadeOnDelete();
	}
