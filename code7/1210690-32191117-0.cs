    public static string RenderViewToString(this Controller controller, string viewName, object model)
    {
        using (var writer = new StringWriter())
        {
          var viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
          controller.ViewData.Model = model;
          var viewCxt = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, writer);
          viewCxt.View.Render(viewCxt, writer);
          return writer.ToString();
        }
      
    }
