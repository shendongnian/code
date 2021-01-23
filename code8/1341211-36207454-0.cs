    // Some repository class
    public class MyRepository : IMyRepository
    {
        [FromServices]
        public IMyDependency { get; set; }
    
        public MyRepository()
        {
        }
    }
    
    // In startup.cs :
    services.AddScoped<IMyDependency, MyDependency>();
    services.AddScoped<IMyRepository, MyRepository>();
