    public class MyController : Controller
    {
      [HttpGet]
      public Action Result SomeAction()
      {
    
       return View();
    
      }
      [HttpPost]
      public Action Result SomeAction(MyModel model)
      {
       
       string name = model.Name;// here you will have name value which was entered in textbox
    
       return View();
    
      }
    
    }
