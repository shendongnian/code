    public class SomeController : Controller
    {
        IDataComponent _dataComponent;
        public SomeController(IDataComponent dataComponent)
        {
            _dataComponent = dataComponent;
        }
        [Route("someRoute")]
        [HttpGet]
        public ViewResult SomeRoute()
        {
            // Now we're using the interface that was injected
            return View(_dataComponent.GetSomeData());
        }
    }
