    namespace AdvancedDI.Controllers
    {
        public class ProductController : ApiController
        {
    		public IFactory iFactory { get; set; }
    
    		protected override void Initialize(HttpControllerContext controllerContext)
    		{
    			DIAPP.GetContainer(this);
    			base.Initialize(controllerContext);
    		}
    
    		public IHttpActionResult Get()
    		{
    			var response = iFactory.DoWork();
    			return Ok(response);
    		}
    
    		protected override void Dispose(bool disposing)
    		{
    			DIAPP.Dispose(this);
    			base.Dispose(disposing);
    		}
    	}
    }
