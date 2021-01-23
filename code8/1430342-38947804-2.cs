    public class ProductsController : BaseController 
    {
       public ActionResult Die()
       {
         throw new Exception("I lost!");
       }
    }
