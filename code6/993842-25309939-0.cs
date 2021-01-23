    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count == 0)
        {
            Response.Redirect("~/index.html");
            return;
        }
    
        if (!Page.IsPostBack)
        {
            //code
        }
    }
