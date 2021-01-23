    public class HomeController : Controller
    {
        IDataProtector _protector;
            
        public HomeController(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector(GetType().FullName);
        }
    }
