    private void Page_Load(object sender, System.EventArgs e)
    {
      if(!IsPostBack)
      {
        Session.Abandon();
        Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
      }
    }
