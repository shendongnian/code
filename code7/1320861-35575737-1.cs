    protected void Page_Load(object sender, EventArgs e)
    {
      if (!User.Identity.IsAuthenticated)
      {
        Response.Redirect("~/login.aspx?ReturnUrl=userLevel.aspx");
        return;
      }
      if(!IsPostBack)
      {
        if (Request.Form["action"] == "userData")
        {
           Response.Clear();
           // if you want data to be specific , you should set content type
           // Set the ContentType
           //Response.ContentType = "application/json";
           Response.Write("some data");
           Response.End();
        }
      }
    }
