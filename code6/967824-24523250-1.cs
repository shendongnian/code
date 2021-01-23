    public class YourContext : DbContext
    {
        public DbSet<MyTable> MyTables { get; set; }
        protected override void OnModelCreating(DbModelBuilder builder)
        {
		    builder.Entity<MyTable>().HasKey(table => new {table.Id, table.Name});
        }
    }
