    public partial class Employee : Person
    {   
        public string EmployeeCode { get; set; } 
    }
    public class EmployeeMapping : EntityTypeConfiguration<Employee>
    {
         HasKey(x => x.Id);
         ToTable("dbo.TB_EMPLOYEE");     
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
         modelBuilder.Configurations.Add(new PersonMapping());
    }
