    public static string RenderRazorViewToString(string viewName, object model)
    {
      HttpContext context = GetContext();
      HttpContextWrapper httpContext = new HttpContextWrapper(context);
      RouteData routeData = new RouteData();
      routeData.Values.Add("controller", "HtmlFake");
      RequestContext requestContext = new RequestContext(httpContext, routeData);
      ControllerContext controllerContext = new ControllerContext(requestContext, new HtmlFakeController());
      using (var sw = new StringWriter())
      {
        ViewDataDictionary viewData = new ViewDataDictionary(model);
        ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(controllerContext, viewName);
        TempDataDictionary tempData = new TempDataDictionary();
        ViewContext viewContext = new ViewContext(controllerContext, viewResult.View, viewData, tempData, sw);
        viewResult.View.Render(viewContext, sw);
        viewResult.ViewEngine.ReleaseView(controllerContext, viewResult.View);
        return sw.GetStringBuilder().ToString();
      }
    }
    public class HtmlFakeController : Controller
    {
    }
