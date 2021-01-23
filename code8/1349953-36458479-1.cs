    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        { 
             // This page is initially being loaded, check the Session
             // and use it
             txtName.Text = Convert.ToString(Session["name"]);
        }
        else
        {
             // It's not a Postback, so store the value for later use
             Session["name"] = txtName.Text.Trim();
        } 
        // Your other code here
    }
