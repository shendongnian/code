        protected void Application_Error(object sender, EventArgs e)
    {
        try
        {
            HandleApplicationErrors();
            Response.TrySkipIisCustomErrors = true;
        }
        catch(Exception ex)
        {
            Response.Write(ex.ToString());
            Response.StatusCode = 500;          
        }
    }
    private void HandleApplicationErrors(int? statusCode = null)
    {
        try
        {
            Exception ex = Server.GetLastError();
            Response.Clear();
            HttpException httpEx = ex as HttpException;
            if (statusCode == null && httpEx != null) statusCode = httpEx.GetHttpCode();
            RouteData routeData = new RouteData();
            routeData.Values.Add("controller", "Error");
            switch (statusCode)
            {
                case 404:
                    routeData.Values.Add("action", "NotFound");
                    break;
                case 403:
                    routeData.Values.Add("action", "Forbidden");
                    break;
                default:
                    routeData.Values.Add("action", "ServerError");
                    break;
            }
            //routeData.Values.Add("exception", ex);
            Server.ClearError();
            this.Server.ClearError();
            this.Response.TrySkipIisCustomErrors = true;
            IController controller = new ErrorController();
            controller.Execute(new RequestContext(new     HttpContextWrapper(this.Context), routeData));
        }
        catch(Exception ex)
        {
            Response.Write(ex.ToString());
            Response.StatusCode = 500;
        }
    }
