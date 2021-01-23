    public static class PartialViewToString
    {
        public static async Task<string> ToString(this PartialViewResult partialView, ActionContext actionContext)
        {
            using(var writer = new StringWriter())
            {
                var services = actionContext.HttpContext.RequestServices;
                var executor = services.GetRequiredService<PartialViewResultExecutor>();
                var view = executor.FindView(actionContext, partialView).View;
                var viewContext = new ViewContext(actionContext, view, partialView.ViewData, partialView.TempData, writer, new HtmlHelperOptions());
                await view.RenderAsync(viewContext);
                return writer.ToString();
            }
        }
    }
