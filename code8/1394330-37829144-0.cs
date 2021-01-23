     public void ConfigureServices(IServiceCollection services)
     {
          services.Configure<ExampleOption>(myOptions =>
          {
              myOptions.Array = new int[] { 1, 2, 3 };
          });
     }
