        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["ConfirmEmail"] != null)
            {
                if (filterContext.HttpContext.Session["ConfirmEmail"] is bool && (bool) filterContext.HttpContext.Session["ConfirmEmail"])
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary
                        {
                            {"controller", "Account"},
                            {"action", "ConfirmEmail"}
                        });
                }
            }
        }
