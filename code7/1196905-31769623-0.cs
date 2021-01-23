    [Route("api/[controller]/[action]")]
    public class ProductsController : Controller
    {
        [Route("{id:int}")]
        public JsonResult Details(int id)
        {
            // ...
        }
    }
