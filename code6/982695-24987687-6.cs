    pubic class HomeController : Controller
    {
    
      [HttpPost]
      public ActionResult Login(LoginModel model) 
      {
            //Some code here
            return View("Index");
      }
    
    }
