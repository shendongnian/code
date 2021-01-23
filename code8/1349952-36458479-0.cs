    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        { 
             // This page is initially being loaded, check the Session
             txtName.Text = Convert.ToString(Session["name"]);
        }
        else
        {
             // It's not a Postback, so store the value
             Session["name"] = txtName.Text.Trim();
        } 
        // Your other code here
    }
