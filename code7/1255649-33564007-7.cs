     public class MyContext : DbContext 
      { 
        public DbSet<DesignationHierarchy> DesignationHierarchys { get; set; } 
        public DbSet<EmployeeInformation> EmployeeInformations{ get; set; } 
      } 
