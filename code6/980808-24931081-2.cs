    protected void Page_Load(object sender, EventArgs e)
    {
       if (Request.QueryString["name"] != null && !String.IsNullOrEmpty(Request.QueryString["name"].ToString())
       {
           string myNameValue = Request.QueryString["name"].ToString();
           //Since you have the name in the querystring, pass value to method that retrieves the record
           User userDetails = SomeLogic.GetUser(name);
       }
    }
