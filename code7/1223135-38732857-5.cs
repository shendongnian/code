    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ViewEngines;
    
    namespace YourNameSpace
    {
        public class YourController : BaseController
        {
            public YourController(ICompositeViewEngine viewEngine) : base(viewEngine) { }
    
            public string Index(int? id)
            {
                var model = new MyModel { Name = "My Name" };
    
                return RenderViewAsString(model);
            }
        }
    }
