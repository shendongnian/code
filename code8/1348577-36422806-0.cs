    public class AccountController : Controller      
    {    
    [System.Web.Http.HttpPost]       
    public ActionResult PostData()
        {
            var data = HttpContext.Request.Headers["UserDetails"];
            return null;
        }   
    }  
