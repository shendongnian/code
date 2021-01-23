    protected void Page_Load(object sender, EventArgs e)
            {
                if (Request.UrlReferrer == null || Request.UrlReferrer.Host != "www.test.com")
                {
                    Response.Redirect("~/redirect.aspx");
                }
            }
