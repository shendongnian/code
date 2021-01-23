    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ViewEngines;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.IO;
    
    namespace YourNameSpace
    {
        public class BaseController : Controller
        {
            protected ICompositeViewEngine viewEngine;
    
            public BaseController(ICompositeViewEngine viewEngine)
            {
                this.viewEngine = viewEngine;
            }
    
            protected string RenderViewAsString(object model, string viewName = null)
            {
                viewName = viewName ?? ControllerContext.ActionDescriptor.ActionName;
                ViewData.Model = model;
    
                using (StringWriter sw = new StringWriter())
                {
                    IView view = viewEngine.FindView(ControllerContext, viewName, true).View;
                    ViewContext viewContext = new ViewContext(ControllerContext, view, ViewData, TempData, sw, new HtmlHelperOptions());
    
                    view.RenderAsync(viewContext).Wait();
    
                    return sw.GetStringBuilder().ToString();
                }
            }
        }
    }
