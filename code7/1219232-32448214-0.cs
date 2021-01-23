    public virtual ActionResult Index()
        {
            var action = RouteData.Values["x-action"].ToString();
            var controller = RouteData.Values["x-controller"].ToString();
            RouteData.Values["action"] = action;
            RouteData.Values["controller"] = controller;
            if (RouteData.Values["area"] != null)
            {
                RouteData.DataTokens["area"] = RouteData.Values["area"].ToString();
            }
    
            return View(action);
        }
