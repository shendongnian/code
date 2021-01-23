	protected void Application_Error(Object sender, EventArgs e)
    {    
        var exception = Server.GetLastError();   
        if (exception != null && exception != 404)
        {    
            Session["w"] = exception;
            Response.Clear();
            Server.ClearError();
            Response.Redirect("~/Admin/Error");    
        }
    }
