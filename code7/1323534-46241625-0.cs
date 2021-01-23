     using System.IO;
     using Microsoft.AspNetCore.Mvc;
     using Microsoft.Extensions.Logging;
     public class IndexController : Controller
     {
        ILoggerFactory Logger;
        public IndexController(ILoggerFactory loggerFactory)
        {
            Logger = loggerFactory;
        }
        
        static string sep = Path.DirectorySeparatorChar.ToString();
        [HttpGet("/index")]
        [HttpGet("/")]
        public IActionResult Index()
        {
            var log = Logger.CreateLogger("trace");
            
            var path = $"{Startup.RootPath}{sep}index.html";
            log.LogWarning(path);
            Stream fileStream  = new System.IO.FileStream(path, FileMode.Open);
            return File(fileStream, "text/html");
        }
    }
    
    // AspnetCore version 1.1.1 :
    // <TargetFramework>netcoreapp1.1</TargetFramework>
    // <PackageReference Include="Microsoft.AspNetCore.StaticFiles" Version="1.1.1" />
