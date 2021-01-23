        using Microsoft.AspNetCore.Mvc;
        using MyLibrary;
        namespace AspCoreAppWithLib.Controllers
        {
            public class HelloWorldController : Controller
            {
                [HttpGet("/read-file")]
                public string ReadFileFromLibrary()
                {
                    return MyClass.ReadFoo();
                }
            }
        }
  
