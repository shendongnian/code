    public class MyController : Controller
    {
        private readonly IContext Context;
        private readonly IServiceProvider _Provider;
        
        public MyController(IContext context, IServiceProvider provider)
        {
            Context = context;
            _Provider = provider;
        }
        
        public IActionResult Index(string className)
        {            
            return View(_Provider.GetService(Type.GetType(className)));
        }
    }
