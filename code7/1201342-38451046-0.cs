        protected string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.ActionDescriptor.ActionName;
            ViewData.Model = model;
            using (StringWriter sw = new StringWriter())
            {
                var engine = _serviceProvider.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine; // Resolver.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
                ViewEngineResult viewResult = engine.FindView(ControllerContext, viewName, false);
                ViewContext viewContext = new ViewContext(
                    ControllerContext,
                    viewResult.View,
                    ViewData,
                    TempData,
                    sw,
                    new HtmlHelperOptions() //Added this parameter in
                );
                //Everything is async now!
                var t = viewResult.View.RenderAsync(viewContext);
                t.Wait();
                return sw.GetStringBuilder().ToString();
            }
        }
