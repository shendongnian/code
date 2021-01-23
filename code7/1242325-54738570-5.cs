    public static class ViewToStringRenderer
    {
        public static async Task<string> RenderViewToStringAsync<TModel>(IServiceProvider requestServices, string viewName, TModel model)
        {
            var viewEngine = requestServices.GetRequiredService(typeof(IRazorViewEngine)) as IRazorViewEngine;
            ViewEngineResult viewEngineResult = viewEngine.GetView(null, viewName, false);
            if (viewEngineResult.View == null)
            {
                throw new Exception("Could not find the View file. Searched locations:\r\n" + string.Join("\r\n", viewEngineResult.SearchedLocations));
            }
            else
            {
                IView view = viewEngineResult.View;
                var httpContextAccessor = (IHttpContextAccessor)requestServices.GetRequiredService(typeof(IHttpContextAccessor));
                var actionContext = new ActionContext(httpContextAccessor.HttpContext, new RouteData(), new ActionDescriptor());
                var tempDataProvider = requestServices.GetRequiredService(typeof(ITempDataProvider)) as ITempDataProvider;
    
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
