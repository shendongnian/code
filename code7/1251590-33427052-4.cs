	class MyTable
	{
		public int Value { get; set; }
	}
	
	class MyTableConfiguration : EntityTypeConfiguration<MyTable>
	{
		public MyTableConfiguration()
		{
			ToTable("dbo.MyTable");
			HasKey(x => x.Value);
			Property(x => x.Value).HasColumnName("Value").IsRequired();
		}
	}
		
	class MyDbContext : DbContext
	{
		public IDbSet<MyTable> MyTableSet { get; set; }
	
		public MyDbContext(string connectionString) : base(connectionString)
		{
		}
	
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Configurations.Add(new MyTableConfiguration());
		}
	}
	
	void Main()
	{
		MyDbContext context = new MyDbContext("Data Source=(local);Initial Catalog=SO33426289;Integrated Security=True;");
		Expression<Func<MyTable, bool>> expr = x => x.Value == 42;
		context.MyTableSet.Where(expr).Dump();
	}
	
