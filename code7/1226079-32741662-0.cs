        protected void Application_Error()
        {
            if (Context.IsCustomErrorEnabled)
            {
                ShowWebErrorPage(Server.GetLastError());
            }
        }
        private void ShowWebErrorPage(Exception exception)
        {
            var httpException = exception as HttpException ?? new HttpException(500, "Internal Server Error", exception);
            Response.Clear();
            var routeData = new RouteData();
			// these depend on your Error controller's logic and routing settings
            routeData.Values.Add("controller", "Error");
            routeData.Values.Add("action", "Index");
            routeData.Values.Add("statusCode", httpException.GetHttpCode());
            Server.ClearError();
            IController controller = new Controllers.ErrorController();
            controller.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
        }
