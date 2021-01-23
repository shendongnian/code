    public class ProductsController : Controller
    {
        public ActionResult Product(string view)
        {
           if(!string.IsNullOrEmpty(view))
           {
                switch(view.ToLower()){
                     case "detail": return View("Detail");
                     case "option1": return View("Option1");
                     case "option2": return View("Option2");
                 }
            }
            return View();
        }
    }
