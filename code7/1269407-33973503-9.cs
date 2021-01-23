    public class ProductController
    {
      public ActionResult Products()
      {
        ProductViewModel productViewModel = new ProductViewModel { /*Initialize properties here*/};
        AppViewModel model = AppViewModel { ProductViewModel  = new List<ProductViewModel>{ new ProductViewModel =  productViewModel }};
        return View(model);
      }
    }
