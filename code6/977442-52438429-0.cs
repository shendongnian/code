    public class MyDatabaseContext : DbContext 
    {
      public MyDatabaseContext() : base ("name=defaultConnection")
      {
        // other code
      }
      
      // other code
    }
