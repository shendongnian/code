    using Microsoft.AspNet.Mvc;
    
    namespace ViewComponentAjax
    {
        public class HelloWorldViewComponent : ViewComponent
        {
            public IViewComponentResult Invoke()
            {
                var model = new string[]
                {
                    "Hello", "from", "the", "view", "component."  
                };
                
                return View("Default", model);
            }     
        }
    }
