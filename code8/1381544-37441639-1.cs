    public static class ControllerExtensions
    {
        public static IActionResult View(this Controller instance, object model, string layout)
        {
            instance.ViewData.Add(ViewDataType.Layout, layout);
            return instance.View(model);
        }
        public static IActionResult View(this Controller instance, string viewName, object model, string layout)
        {
            instance.ViewData.Add(ViewDataType.Layout, layout);
            return instance.View(viewName, model);
        }
    }
