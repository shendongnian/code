    public string RenderPartialViewToString(string viewName, object model)
    {
        if (string.IsNullOrEmpty(viewName))
            viewName = ActionContext.ActionDescriptor.Name;
    
        ViewData.Model = model;
    
        using (StringWriter sw = new StringWriter())
        {
            var engine = Resolver.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
            ViewEngineResult viewResult = engine.FindPartialView(ActionContext, viewName);
    
            ViewContext viewContext = new ViewContext(ActionContext, viewResult.View, ViewData, TempData, sw,new HtmlHelperOptions());
    
            var t = viewResult.View.RenderAsync(viewContext);
            t.Wait();
    
            return sw.GetStringBuilder().ToString();
        }
    }
