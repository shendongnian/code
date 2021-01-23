    // all actions in FooController require authentication
    [Authorize]
    public class FooController : Controller
    {
        public async Task<ActionResult> FooAction()
        {        
        
        }
        public async Task<ActionResult> BarAction()
        {
        
        }
    }
