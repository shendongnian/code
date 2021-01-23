    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["MyCookies"] != null)
        {
            string userSettings = Request.Cookies["MyCookies"].Value;
       
        }
      
    }
