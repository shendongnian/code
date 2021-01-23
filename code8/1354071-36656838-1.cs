    [Route("[controller]")]
    public class ErrorController : Controller
    {            
         [HttpGet("{statusCode}")]
         public IActionResult Error(int statusCode)
         {     
               //switch (statusCode)
	           //{  
               //    return different views...
               //}
               Response.StatusCode = statusCode;
               return View("Error", statusCode);
         }
    }
