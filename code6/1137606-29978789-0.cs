    public class testEF : DbContext {
        public IDbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Configurations.Add(new EmployeeEFConfiguration());
        }
    }
    public class EmployeeEFConfiguration : EntityTypeConfiguration<Employee> {
        public EmployeeEFConfiguration() {
            HasRequired(x => x.Dep).WithMany(y => y.Employees);
        }
    }
