    public class ProductsController:Controller
    {
      Public ActionResult Index(int Id)
      {
      //some code to load and return the productDetails
      }
      public ActionResult IncreaseProductCount(int Id)
      {
       //increase the count
        return RedirectToAction("Index",new{Id=Id});
       }
    }
