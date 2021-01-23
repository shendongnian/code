    private async Task<string> RenderView(string path, ViewDataDictionary viewDataDictionary, ActionContext actionContext)
    {
        using (var sw = new System.IO.StringWriter())
        {
            var viewResult = viewEngine.FindView(actionContext, path);
            var viewContext = new ViewContext(actionContext, viewResult.View, viewDataDictionary, new TempDataDictionary(httpContextAccessor, tempDataProvider), sw);
            await viewResult.View.RenderAsync(viewContext);
            sw.Flush();
            if (viewContext.ViewData != viewDataDictionary)
            {
                var keys = viewContext.ViewData.Keys.ToArray();
                foreach (var key in keys)
                {
                    viewDataDictionary[key] = viewContext.ViewData[key];
                }
            }
            return sw.ToString();
        }
    }
