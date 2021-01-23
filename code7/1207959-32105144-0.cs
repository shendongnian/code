    public class User
    {
         public int Id {get;set;}
         public virtual Address Address {get;set;}
         
         
    }
    
    public class Address
    {
         public int Id {get;set;}
         //Some other properties
    }
    
    
    
    
    public class UserMapping: EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
             HasOptional(u => u.Address).WithMany()
                                       .Map(m => m.MapKey("Id_Address"));
             
        }
    }
    //Override the OnModelCreating method in the DbContext
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
          modelBuild.Configurations.Add(new UserMapping());
    }
