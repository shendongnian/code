    public class ErrorController : Controller
    {
      public ViewResult Index()// It is used for **defaultRedirect**
      {
        return View("Error");
      }
      public ViewResult Error404()
      {
        Response.StatusCode = 404;  
        return View("Error404");// Not found
      }
      public ViewResult Error403()
      {
        Response.StatusCode = 403; 
        return View("UnauthorizedAccess");
      }
      
    }
