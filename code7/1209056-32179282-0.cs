    protected void Application_EndRequest(object sender, EventArgs e)
    {
        if (Response.StatusCode == 401)
        {
            Response.ClearContent();
            Response.WriteFile("~/Static/NotAuthorized.html");
            Response.ContentType = "text/html";
        }
    }
