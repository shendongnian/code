    protected string RenderPartialViewToString(string viewName, object model)
        {
            var view = viewName;
            if (string.IsNullOrEmpty(view))
            {
                view = ControllerContext.RouteData.GetRequiredString("action");
            }
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, view);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                return sw.GetStringBuilder().ToString();
            }
        }
