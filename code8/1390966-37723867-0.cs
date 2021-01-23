    void Application_Start(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(60000);//86400000 milisecond is equal to 24;
        Response.Redirect("~/Authorize.aspx");
    }
