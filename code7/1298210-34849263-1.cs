      protected void Application_EndRequest(object sender, System.EventArgs e)
        {
            switch (Response.StatusCode)
            {
                case 404:
                    Response.ClearContent();
                    Response.RedirectToRoute("Default", new RouteValueDictionary() { { "controller", "error" }, { "action", "Index" }, { "statuscode", Response.StatusCode } });
                    break;
            }
        }
