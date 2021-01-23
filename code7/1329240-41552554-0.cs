    using Microsoft.AspNetCore.Hosting;
    ....
    public class HomeController: Controller
    {
       private IHostingEnvironment _env;
    
       public HomeController(IHostingEnvironment env)
       {
       _env = env;
       }   
    ...
