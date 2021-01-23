	protected override void OnModelCreating(ModelBuilder builder)
    {
		modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		modelBuilder.Entity<PostComment>().HasRequired<BlogPost>(c => c.ParentPost)
                .WithMany(p => p.Comments);
        base.OnModelCreating(builder);
    }
 
