    protected void LinkButton1_Click(object sender, EventArgs e)
        {
    
             if (Request.Cookies["ASP.NET_SessionId"] != null)
             {
                 Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                 Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
             }
             FormsAuthentication.SignOut();
             Session.Abandon();
             PostBackOptions myPostBackOptions = new PostBackOptions(this);
             myPostBackOptions.ActionUrl = "~/Default.aspx";
             myPostBackOptions.AutoPostBack = false;
             myPostBackOptions.RequiresJavaScriptProtocol = true;
             myPostBackOptions.PerformValidation = true;
    
             // Add the client-side script to the HyperLink1 control.
             LinkButton1.OnClientClick = Page.ClientScript.GetPostBackEventReference(myPostBackOptions);
             Response.Redirect("~/Default.aspx");
        }
