      public class MyContext : DbContext
      {
          public MyContext (){}
           public DbSet<MyModel> MyModel { get; set; }
      }
