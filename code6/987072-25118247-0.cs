    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        if (Request.Url.AbsolutePath.EndsWith("/"))
        {
            Server.Transfer(Request.Url.AbsolutePath + "default.aspx");
        }
    }
}
