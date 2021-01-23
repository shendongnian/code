    public class MyContext : IdentityDbContext<ApplicationUser>
        {
            public MyContext()
                : base("MyConnection")
            {
    
            }
    
    
            static MyContext()
            {
                Database.SetInitializer<MyContext>(new ApplicationDbInitializer());
            }
    
            public static MyContext Create()
            {
                return new MyContext();
            }
