    protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
    {
            if (Request.IsAuthenticated)
            {
                var principal = new CustomPrincipal(HttpContext.Current.User);
                HttpContext.Current.User = principal;
            }
    }
