    [RoutePrefix("product")]
    public class ProductController : Controller {
    //route /product
    [Route] 
    public ActionResult Index() { ... } 
    //route /product/add
    [Route("add")]
    public ActionResult Add() { ... }
    //route /product/like
    // <a href="@Url.RouteUrl("productLike")">Like</a>
    [Route("like", Name="productlike")]
    public ActionResult Like() { ... }
    //route /product/{id}/{seoName}
    [Route("{id?}/{seoName?}")]
    public ActionResult Get(int? id, string seoName) { ... }
    }
