    [Route("api/[controller]")]
    public class ProductController : Controller
    {
    	[HttpGet]
    	public IActionResult GetAll()
    	{
    		var products = //..make call to service or query to get products..
    		
    		var results = new List<ProductDTO>();
    		foreach (var product in products) 
    		{
    			// merge objects into new ProductDTO collection
    			results.Add(a=> new ProductDTO() {Id = a.Id, Name = a.Name ...});
    		}
    		return new JsonResult(values);
    	}
    }
