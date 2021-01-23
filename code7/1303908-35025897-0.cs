        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception.GetType() == typeof(System.ArgumentException))
            {
                //This simply surpresses MVC from raising exception
                filterContext.ExceptionHandled = true;
                //Some logic to create a default "SettingsRoot" parameter
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "controller", "Default" },
                    { "action", "MyActionMethod" },
                    { "settings", new SettingsRoot() }
                });
            }
        }
