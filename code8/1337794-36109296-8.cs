     public class MyEventController : Controller
     {
            
         [HttpPost]
         public ActionResult Save(InputEvent model)
         {     
             // Your other implementation.
             // Consider refining the implementation to use Stored Procedures or an ORM e.g. Entity Framework. 
             // It helps secure your app. Application security advice.        
             return View();
         }
    
         [HttpGet]
         public ActionResult Save()
         {                
             return View();
         }
     }
