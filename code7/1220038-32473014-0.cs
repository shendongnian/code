    void Application_BeginRequest(Object source, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Host.ToLower();
            if (host == "www.mysite.com")
            {
                //Incase if you are using any session
                if (Session["User"] == null)
                    Response.Redirect("Login.aspx");
                else
                {
                    //validate the session
                    Response.Redirect("Home.aspx");
                }
            }
            else if (host == "sample.mysite.com")
            {
                Response.Redirect("Welcome.aspx");
            }
        }
