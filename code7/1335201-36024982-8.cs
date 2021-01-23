    using Microsoft.AspNet.Mvc;
    
    namespace ViewComponentAjax
    {
        public class HelloWorldViewComponent : ViewComponent
        {
            public IViewComponentResult Invoke()
            {
                return View("Default", "Hello World.");
            }     
        }
    }
