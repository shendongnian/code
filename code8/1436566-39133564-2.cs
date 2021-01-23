    public class SomeController : Controller
    {
        [Route("someRoute")]
        [HttpGet]
        public ViewResult SomeRoute()
        {
            // Here we're using the data component directly
            var dataComponent = new DataAccessLayer.DataComponent();
            return View(dataComponent.GetSomeData());
        }
    }
