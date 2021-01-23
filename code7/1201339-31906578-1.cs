    public class MyController : Controller
    {
        private ICompositeViewEngine _viewEngine;
        public MyController(ICompositeViewEngine viewEngine)
        {
            _viewEngine = viewEngine;
        }
        //Rest of the controller code here
    }
