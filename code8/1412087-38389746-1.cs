    public partial class Employee  
    {  
       // These fields come from the “Employee” table  
       public int EmployeeId { get; set; }   
       public string Code { get; set; }  
       public string Name { get; set; }  
      
       // These fields come from the “EmployeeDetails” table  
       public string PhoneNumber { get; set; }  
       public string EmailAddress { get; set; }  
    } 
    public partial class Model : DbContext  
    {  
       public Model() : base("name=EntityModel")  
       {  
          Database.Log = Console.WriteLine;  
       }  
       public virtual DbSet<Employee> Employees { get; set; }  
      
       protected override void OnModelCreating(DbModelBuilder modelBuilder)  
       {  
          modelBuilder.Entity<Employee>()  
          .Map(map =>  
          {  
              map.Properties(p => new  
              {  
                 p.EmployeeId,  
                 p.Name,  
                 p.Code  
              });  
              map.ToTable("Employee");  
          })  
          // Map to the Users table  
          .Map(map =>  
          {  
              map.Properties(p => new  
              {  
                 p.PhoneNumber,  
                 p.EmailAddress  
              });  
              map.ToTable("EmployeeDetails");  
          });  
       }  
    }
