    public class FooController : Controller
    {
        // only FooAction requires authentication in FooController
        [Authorize]
        public async Task<ActionResult> FooAction()
        {        
        
        }
        public async Task<ActionResult> BarAction()
        {
        
        }
    }
