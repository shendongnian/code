    public class Model1 : DbContext
    {
		public Model1()
			: base("name=Model1")
		{
		}
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AObject>()
				.HasRequired(e => e.RootObject).WithOptional(r => r.AObject);
			modelBuilder.Entity<BObject>()
				.HasRequired(e => e.RootObject).WithOptional(r => r.BObject);
			base.OnModelCreating(modelBuilder);
		}
		public virtual DbSet<RootObject> RootObjects { get; set; }
		public virtual DbSet<AObject> AObjects { get; set; }
		public virtual DbSet<BObject> BObjects { get; set; }
	}
	public class RootObject
	{
		[Key]
		public int RootObjectId { get; set; }
		public virtual AObject AObject { get; set; }
		public virtual BObject BObject { get; set; }
		public string Name { get; set; }
	}
	public class AObject
	{
		[Key]
		public int AObjectId { get; set; }
		public virtual RootObject RootObject { get; set; }
	}
	public class BObject
	{
		[Key]
		public int BObjectId { get; set; }
		public virtual RootObject RootObject { get; set; }
	}
