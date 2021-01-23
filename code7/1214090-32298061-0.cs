            protected void Application_Error()
            {
                var exception = Server.GetLastError();
                var httpException = exception as HttpException;
                Response.Clear();
                Server.ClearError();
                var routeData = new RouteData();
                routeData.Values["controller"] = "Error";
                routeData.Values["action"] = "General";
                routeData.Values["exception"] = exception;
                Response.StatusCode = 500;
                if (httpException != null)
                {
                    Response.StatusCode = httpException.GetHttpCode();
                    switch (Response.StatusCode)
                    {
                        case 403:
                            routeData.Values["action"] = "Forbidden";
                            break;
    
                        case 404:
                            routeData.Values["action"] = "NotFound";
                            break;
                       case 500:
                            routeData.Values["action"] = "UnExpected";
                            break;
                    }
                }
    
                IController errorsController = new ErrorController();
                var rc = new RequestContext(new HttpContextWrapper(Context), routeData);
                errorsController.Execute(rc);
            }
