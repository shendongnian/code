      protected void Application_EndRequest(object sender, System.EventArgs e)
        {
            switch (Response.StatusCode)
            {
                case 401:
                    Response.ClearContent();
                    Response.RedirectToRoute("Default", new RouteValueDictionary() { { "controller", "home" }, { "action", "login" } });
                    break;
                case 403:
                    Response.ClearContent();
                    Response.RedirectToRoute("Default", new RouteValueDictionary() { { "controller", "home" }, { "action", "status" }, { "statuscode", Response.StatusCode } });
                    break;
                case 404:
                    Response.ClearContent();
                    Response.RedirectToRoute("Default", new RouteValueDictionary() { { "controller", "error" }, { "action", "status" }, { "statuscode", Response.StatusCode } });
                    break;
            }
        }
