    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        //required to keep the page from being cached on the client's browser
    
        Response.ContentType = "text/plain";
        Response.Write("Hello");
        Response.End();
    }
    
