    private void Application_Error(object sender, EventArgs e)
    {
        Exception ex = Server.GetLastError();
    
        if (ex is HttpAntiForgeryException)
        {
            Response.Clear();
            Server.ClearError(); //make sure you log the exception first
            Response.Redirect("/error/antiforgery", true);
        }
    }
