        public void Application_Error(Object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            Server.ClearError();
            var routeData = new RouteData();
            routeData.Values.Add("area", "");
            routeData.Values.Add("controller", "Error");
            if (exception.GetType() == typeof(HttpException))
            {
                var code = ((HttpException)exception).GetHttpCode();
                if (code == 404)
                {
                    routeData.Values.Add("action", "Index");
                }
            }
            else
            {
                routeData.Values.Add("action", "Index");
                routeData.Values.Add("statusCode", 500);
            }
            routeData.Values.Add("exception", exception);
            Response.TrySkipIisCustomErrors = true;
            IController controller = new ErrorController();
            controller.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
            Response.End();
        }
