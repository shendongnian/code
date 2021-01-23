     public class MyEventController : Controller
     {
            
         [HttpPost]
         public ActionResult Save(InputEvent model)
         {                
             return View();
         }
    
         [HttpGet]
         public ActionResult Save()
         {                
             return View();
         }
     }
