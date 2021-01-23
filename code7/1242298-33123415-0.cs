    class MyDbContextBase : DbContext
    {
        public DbSet<User> Users { get; set; }
    
        // other code here;
        // DO NOT override OnModelCreating in this class
    }
    
    class MyDbContextA : MyDbContextBase 
    {
         // override OnModelCreating here; 
         // e.g. map Users to schema1.user table
    }
    
    class MyDbContextB : MyDbContextBase 
    {
         // override OnModelCreating here; 
         // e.g. map Users to schema2.user
    }
