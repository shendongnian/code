    public class AnotherController : Controller
    {
        private AnotherClass _anotherClass;
    
        public AnotherController(AnotherClass anotherClass)
        {
            _anotherClass = anotherClass;
            // _anotherClass will have both ApplicationDbContext and MyClass injected by the service provider
        }
    }
