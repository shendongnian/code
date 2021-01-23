    public class MyContext: DbContext 
            {
                public MyContext(): base("MyContext") 
                {
                }
        
                public DbSet<Student> Students { get; set; }
                
                protected override void OnModelCreating(DbModelBuilder modelBuilder)
                {
                    //Configure default schema
                    modelBuilder.HasDefaultSchema("Ordering");
                }
            }
            
