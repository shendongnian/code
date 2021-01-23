    public class ApplicationDbContext() : System.Data.Entity.IDbContext
    {
        public ApplicationDbContext() : base("my_connection_string_name")
        { }
        ... // Rest of context class definition
    }
