    public class CustomSection 
    {
       public int A {get;set;}
       public int B {get;set;}
    }
    //In Startup.cs
    services.Configure<CustomSection>(Configuration.GetSection("CustomSection"));
    //You can then inject an IOptions instance
    public HomeController(IOptions<CustomSection> options) 
    {
        var settings = options.Value;
    }
