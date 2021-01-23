     protected void Page_Load(object sender, EventArgs e)
        {
        if (Request.Browser.Cookies)
            {
                //supports the cookies
             Response.Cookies["MyCookies"].Value = Request.QueryString["id"];
            }
        else
        {
            //not supports the cookies
            //redirect user on specific page
            //for this or show messages
        }
        }
