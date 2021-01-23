    public class HomeController:Controller
       {
    
         public ActionResult Method1()
         {
           return View();
         }
    
         [Authorize(Users="user1")]
         public ActionResult Method2()
         {
           return View();
         }
       }
