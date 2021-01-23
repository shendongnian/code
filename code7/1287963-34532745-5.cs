     public class ApplicationDbContext : DbContext
        {
            public DbSet<ClassB> BList { get; set; }
    
            public ApplicationDbContext()
                : base("DefaultConnection", throwIfV1Schema: false)
            {
            }
            
            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }
    
        }
        public class ClassB
        {
            public ClassB()
            {
                BId = Guid.NewGuid().ToString();
    
            }
             [Key]
            public string BId { get; set; }
        
    
        }
