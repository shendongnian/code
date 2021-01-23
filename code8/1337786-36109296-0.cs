     public class MyEvent : Controller
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
