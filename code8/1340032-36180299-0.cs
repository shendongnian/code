    protected void Application_EndRequest()
    {
        var response = new HttpResponseMessage((HttpStatusCode)Context.Response.StatusCode);
        if (!response.IsSuccessStatusCode)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    ErrorAction("BadRequest");
                    break;
                case HttpStatusCode.NotFound:
                    ErrorAction("NotFound");
                    break;
                case HttpStatusCode.InternalServerError:
                    ErrorAction("InternalServerError");
                    break;
                case HttpStatusCode.Forbidden:
                    ErrorAction("Forbidden");
                    break;
                default:
                    ErrorAction("GenericError");
                    break;
            }
        }
    }
    // Sends a request to the ErrorController
    private void ErrorAction(string action)
    {
        var rd = new RouteData();
        IController c = new ErrorController();
        Response.Clear();
            
        rd.Values["controller"] = "Error";
        rd.Values["action"] = action;
            
        c.Execute(new RequestContext(new HttpContextWrapper(Context), rd));
    }
