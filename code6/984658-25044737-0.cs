    public override void OnResultExecuted(ResultExecutedContext filterContext) {
        if (!DisableUiTools) {
            using (var sw = new StringWriter()) {
                filterContext.Controller.ViewData.Model = filterContext.RouteData.GetCurrentPage<IPage>();
                    var viewResult = ViewEngines.Engines.FindPartialView(filterContext.Controller.ControllerContext, "~/Areas/UI/Views/Shared/_UIControls.cshtml");
                    var viewContext = new ViewContext(filterContext.Controller.ControllerContext, viewResult.View, filterContext.Controller.ViewData, filterContext.Controller.TempData, sw);
                    viewResult.View.Render(viewContext, sw);
                    viewResult.ViewEngine.ReleaseView(filterContext.Controller.ControllerContext, viewResult.View);
                    var response = filterContext.HttpContext.Response;
                    response.Filter = new AddUiToolsFilter(response.Filter, sw.GetStringBuilder().ToString());
                }
            }
        }else
            base.OnResultExecuted(filterContext);
    }
