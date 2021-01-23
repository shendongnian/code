    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count == 0)
        {
            Response.Redirect("~/index.html");
            return; //return here so this logic isn't mixed with the postback logic.
        }
    
        if (!Page.IsPostBack)
        {
            //code
        }
    }
