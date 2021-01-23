        // Add key value    
		RouteData route = new RouteData();
        route.Values.Add("action", "GetPDF"); // ActionName
        route.Values.Add("controller", "PDF"); // Controller Name
        System.Web.Mvc.ControllerContext newContext = new System.Web.Mvc.ControllerContext(new HttpContextWrapper(System.Web.HttpContext.Current), route, controller);
        controller.ControllerContext = newContext;
        controller.GetPDF();
