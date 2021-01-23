    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    namespace EntityFrameworkModelFirst
    {   
        public partial class ModelFirstContainer : DbContext
        {
            public ModelFirstContainer() : base("name=ModelFirstContainer")
            {
            }
    
            public virtual DbSet<Department> DepartmentSet { get; set; }
            public virtual DbSet<Employee> EmployeeSet { get; set; }
        }
    
        public class SomeClass
        {
            public void DoSomeStuff()
            {
                 using (var context = new ModelFirstContainer()) 
                 {     
                     // Perform data access using the context 
                 }
            }
        }
    }
