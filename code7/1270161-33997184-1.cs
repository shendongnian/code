    public class ProductsController : Controller
    {
        public ActionResult Product(int id, string view,)
        {
           Product prod = Context.GetProduct(id);
           if(!string.IsNullOrEmpty(view))
           {
                switch(view.ToLower()){
                     case "detail": return View("Detail", prod.Detail);
                     case "option1": return View("Option1", prod.GetOption(1));
                     case "option2": return View("Option2", prod.GetOption(2));
                 }
            }
            return View();
        }
    }
