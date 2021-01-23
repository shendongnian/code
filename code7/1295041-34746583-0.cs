    private readonly IServiceProvider Provider;
    public HomeController(IServiceProvider provider)
    {       
        Provider = provider;
    }
    public IActionResult Index()
    {       
        var instance = ActivatorUtilities.CreateInstance(Provider, typeof(A));
        return View(instance);
    }
    public class A
    {
        public A(IContext context)
        {
        }
    }
