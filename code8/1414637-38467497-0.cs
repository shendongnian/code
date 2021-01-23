    public class MyClass
    {
       private readonly IConfiguration configuration;
       public MyClass(IConfiguration configuration)
       {
          this.configuration = configuration;
          //
          configuration.GetConnectionString("DefaultConnection");
       }
    }
