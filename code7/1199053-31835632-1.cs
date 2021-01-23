    public static string RenderViewToString(Controller controller, 
                                            string viewName, 
                                            object model, 
                                            string masterName)
    {
        controller.ViewData.Model = model;
        using (StringWriter sw = new StringWriter())
        {
            var viewResult = ViewEngines.Engines.FindView(controller.ControllerContext, 
                             viewName, 
                             masterName);
 
            var viewContext = new ViewContext(controller.ControllerContext, 
                                              viewResult.View, 
                                              controller.ViewData, 
                                              controller.TempData, 
                                              sw);
        
            viewResult.View.Render(viewContext, sw);
            return sw.GetStringBuilder().ToString();
        }
    }
