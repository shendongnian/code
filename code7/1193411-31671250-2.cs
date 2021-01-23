    protected void Page_Load(object sender, EventArgs e)
    {
        BreadCrumb();
    
        if (Thread.CurrentThread.CurrentCulture.ToString() == "cy-GB")
        {                
            Footer1.Visible = false;
            Footer2.Visible = true;
            Header1.Visible = false;
            Header2.Visible = true;
        }
    
        if (Thread.CurrentThread.CurrentCulture.ToString() == "en-GB")
        {                
            Footer2.Visible = false;
            Footer1.Visible = true;
            Header1.Visible = true;
            Header2.Visible = false;
        }
    
        Page.Header.DataBind();   
        //clear cache each time page loads
        Response.Expires = 0;
        Response.Cache.SetNoStore();
        Response.AppendHeader("Pragma", "no-cache");
        
    
    private void BreadCrumb()
    {
        string path = HttpContext.Current.Request.Url.AbsolutePath;
    
        if (path == "/LogIn.aspx" || path == "/LogIn.aspx?lang=cy-GB")
        {                
            breadcrumb.Visible = false;                
        }
    }
