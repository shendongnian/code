    using Microsoft.AspNet.Mvc;
    namespace ViewComponentAjax
    {   
        public class HomeController : Controller
        {
            public IActionResult GetHelloWorld()
            {
                return ViewComponent("HelloWorld");
            }
        }
    }
