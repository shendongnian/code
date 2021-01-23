	public class EmployeeContext : DbContext {
		public DbSet<Employee> Employees { get; set; }
		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			modelBuilder.HasDefaultSchema("myschema");
		}
	}
