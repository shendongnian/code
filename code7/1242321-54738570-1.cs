    public static class ViewToStringRenderer
    {
        public static async Task<string> RenderViewToStringAsync<TModel>(IServiceProvider requestServices, string viewName, TModel model)
        {
            var viewEngine = requestServices.GetService(typeof(IRazorViewEngine)) as IRazorViewEngine;
            ViewEngineResult viewEngineResult = viewEngine.GetView(null, viewName, false);
            if (viewEngineResult.View == null)
            {
                throw new Exception("Could not find the View file. Searched locations:\r\n" + viewEngineResult.SearchedLocations);
            }
            else
            {
                IView view = viewEngineResult.View;
                var httpContext = new DefaultHttpContext { RequestServices = requestServices };
                var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());
                var tempDataProvider = requestServices.GetService(typeof(ITempDataProvider)) as ITempDataProvider;
    
                using var outputStringWriter = new StringWriter();
                var viewContext = new ViewContext(
                    actionContext,
                    view,
                    new ViewDataDictionary<TModel>(new EmptyModelMetadataProvider(), new ModelStateDictionary()) { Model = model },
                    new TempDataDictionary(actionContext.HttpContext, tempDataProvider),
                    outputStringWriter,
                    new HtmlHelperOptions());
    
                await view.RenderAsync(viewContext);
    
                return outputStringWriter.ToString();
            }
        }
    }
