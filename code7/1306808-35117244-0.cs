    public class ProductController : Controller
     {
         EFDbContext db = new EFDbContext();
         private IProductsRepository repository;
         public int PageSize = 4;
    
         public ProductController (IProductsRepository productrepository)
         {
              this.repository = productrepository;
         }
         [Route("Product/list/{category}/{page}")]
         public ViewResult List(string category, int page = 1)
         {
           // to do  : Return something
         }
    }
