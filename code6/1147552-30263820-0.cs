    public IConfiguration Configuration { get; set; }
    
    public Startup(IHostingEnvironment environment) 
    {
        Configuration = new Configuration()
          .AddJsonFile("config.json");
        //generally here you'd set up your DI container. But for now we'll just new it up
        MyClass c = new MyClass(Configuration.Get("AppSettings:SomeKey"));
    }
    
    public class MyClass
    {
        private readonly string Setting; //if you need to pass multiple objects, use a custom POCO (and interface) instead of a string.
    
        public MyClass(string setting) //This is called constructor injection
        {
            Setting = setting;
        }
        public string DoSomething() 
        {
            var result = string.Empty;
            //Use setting here
            return result;
        }
    }
