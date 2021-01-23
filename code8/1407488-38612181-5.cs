    private static void RenderPartial(string partialViewName, object model)
        {
            HttpContextBase httpContextBase = new HttpContextWrapper(HttpContext.Current);
            RouteData routeData = new RouteData();
            routeData.Values.Add("controller", "WebFormsUtility");
            routeData.Values.Add("area", "MVC"); //Added area to routeData
            ControllerContext controllerContext = new ControllerContext(new RequestContext(httpContextBase, routeData), new WebFormsUtilityController());
            IView view = FindPartialView(controllerContext, partialViewName);
            ViewContext viewContext = new ViewContext(controllerContext, view, new ViewDataDictionary { Model = model }, new TempDataDictionary(), httpContextBase.Response.Output);
            view.Render(viewContext, httpContextBase.Response.Output);
        }
