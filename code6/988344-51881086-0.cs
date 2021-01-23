    protected string RenderPartialViewToString(ControllerContext context, string viewName, object model)
    {
        var controller = context.Controller;
        if (string.IsNullOrEmpty(viewName))
            viewName = controller.ControllerContext.RouteData.GetRequiredString("action");
    
        ViewData.Model = model;
    
        using (StringWriter sw = new StringWriter())
        {
            ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
            ViewContext viewContext = new ViewContext(controller.ControllerContext, viewResult.View, ViewData, TempData, sw);
            viewResult.View.Render(viewContext, sw);
    
            return sw.GetStringBuilder().ToString();
        }
    }
