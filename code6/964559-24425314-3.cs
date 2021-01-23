    public class ProductController : Controller
    {
         private readonly IProductService prodService;
         public ProductController(IProductService prodService)
         {
             this.prodService = prodService;
         }
    }
