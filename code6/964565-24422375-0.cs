        protected void Page_Load(object sender, EventArgs e)
        {
          if (!IsPostBack)
          {
            Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
            // rest of your code here ...
          }
        }
