    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.AspNetCore.Mvc.Razor;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using System;
    using System.IO;
    
    namespace LibraryApi.Services
    {
        public class ViewRenderService
        {
            IRazorViewEngine _viewEngine;
            IHttpContextAccessor _httpContextAccessor;
    
            public ViewRenderService(IRazorViewEngine viewEngine, IHttpContextAccessor httpContextAccessor)
            {
                _viewEngine = viewEngine;
                _httpContextAccessor = httpContextAccessor;
            }
    
            public string Render(string viewPath)
            {
                return Render(viewPath, string.Empty);
            }
    
            public string Render<TModel>(string viewPath, TModel model)
            {
                var viewEngineResult = _viewEngine.GetView("~/", viewPath, false);
    
                if (!viewEngineResult.Success)
                {
                    throw new InvalidOperationException($"Couldn't find view {viewPath}");
                }
    
                var view = viewEngineResult.View;
                
                using (var output = new StringWriter())
                {
                    var viewContext = new ViewContext();
                    viewContext.HttpContext = _httpContextAccessor.HttpContext;
                    viewContext.ViewData = new ViewDataDictionary<TModel>(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                    { Model = model };
                    viewContext.Writer = output;
    
                    view.RenderAsync(viewContext).GetAwaiter().GetResult();
    
                    return output.ToString();
                }
            }
        }
    }
