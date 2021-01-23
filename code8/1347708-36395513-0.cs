    public class MyController : Controller
    {
       public ActionResult Create(string name)
       {
           if (HttpContext.Current.Request.IsLocal) { ... }
           else { ... }
       }
    }
