        /// <summary> Handle "page not found" (HTTP 404) and "dangerous/invalid syntax" (HTTP 400) errors. </summary>
        protected void Application_EndRequest()
        {
            // This code is adapted from: https://stackoverflow.com/a/9026941/1637105
            var code = Context.Response.StatusCode;
            if (code == 404 || code == 400) {
                Response.Clear();
                var rd = new RouteData();
                rd.DataTokens["area"] = "AreaName"; // In case controller is in another area
                rd.Values["controller"] = "Errors";
                rd.Values["action"] = "NotFound";
                IController c = new ErrorsController();
                c.Execute(new RequestContext(new HttpContextWrapper(Context), rd));
            }
        }
