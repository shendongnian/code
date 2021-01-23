	public class MyDbContext : DbContext
	{
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Review>().HasKey( e => e.Id );
			modelBuilder.Entity<Review>()
				.HasRequired(e => e.PictureInfo)
				.WithRequiredDependent(e => e.Review);
			modelBuilder.Entity<Review>().Map(m => m.ToTable("Review"));
			modelBuilder.Entity<PictureInfo>().Map(m => m.ToTable("Review"));
			modelBuilder.Entity<PictureInfo>().HasKey(e => e.Id);
			base.OnModelCreating(modelBuilder);
		}
		public DbSet<Review> Reviews { get; set; }
		public DbSet<PictureInfo> PictureInfos { get; set; }
	}
