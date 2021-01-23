    protected void Application_Error(object sender, EventArgs e)
    {
        Exception err = Server.GetLastError();
        Session.Add("LastError", err);
    }
    void Session_Start(object sender, EventArgs e) 
    {      
        Session["LastError"] = ""; //initialize the session
    }
