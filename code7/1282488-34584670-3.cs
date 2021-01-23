    public class ProductsController : Controller
    {
          public void Index()
          { 
                var view = new ProductsListView();
                view.Products = _repository.GetProducts();
                return View(view);
          }
    }
