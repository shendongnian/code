     public class MyEventController : Controller
     {
            
         [HttpPost]
         public ActionResult Save(InputEvent model)
         {     
             // Your other implementation.
             // Consider refining the implementation to use Stored Procedures           
             return View();
         }
    
         [HttpGet]
         public ActionResult Save()
         {                
             return View();
         }
     }
