    public class ProductController
    {
      public ActionResult Products()
      {
        ProductViewModel productViewModel = new ProductViewModel { /*Initialize properties here*/};
        AppViewModel model = AppViewModel { ProductViewModel  = productViewModel };
        return View(model);
      }
    }
