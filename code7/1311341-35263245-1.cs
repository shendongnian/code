    void Application_BeginRequest(object sender, EventArgs e)
    {
        if(Request.PhysicalPath.Contains("English")
        {
             if(!((bool)Session["English"]))
                 //Not "English" user - redirect to login or unauthorized page
        }
    }
