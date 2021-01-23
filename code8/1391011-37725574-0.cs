    public class MyController : Controller
    {
        private readonly IMyInterface _myInterface;
        public MyController(IMyInterface myInterface)
        {
            _myInterface = myInterface;
        }
        public JsonResult Get()
        {
            return Json(_myInterface.Get();
        }
    }
    public interface IMyInterface
    {
        IEnumerable<MyObject> Get();
    }
    public class MyClass : IMyInterface
    {
        public IEnumerable<MyObject Get()
        {
            // implementation
        }
    }
