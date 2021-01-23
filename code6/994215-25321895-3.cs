    void Application_Error(object sender, EventArgs e)
    {
        Exception TheError = Server.GetLastError();
        Server.ClearError();
    
        // Avoid IIS7 getting in the middle
        Response.TrySkipIisCustomErrors = true;
    
        if (TheError is HttpException && ((HttpException)TheError).GetHttpCode() == 404)
        {
            Response.Redirect("~/404.aspx");
        }
        else
        {
            Response.Redirect("~/500.aspx");
        }
    }
