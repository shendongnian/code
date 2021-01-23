	public class MyContext: DbContext {
		public MyContext (string connectionString): base(connectionString) { }
		public DbSet<Table1> Table1 { get; set; }
	}
	
