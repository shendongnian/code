    protected void GridView12_Load(object sender, EventArgs e)
    {
    if (Page.IsPostBack == true)
    {
    sqlcommandall();
    }
    else
    {
    sqlcommandone();
    }
    }
