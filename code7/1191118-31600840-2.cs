    protected void Page_Load(object sender, EventArgs e)
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
    protected void sqlcommandall()
    {
    SqlDataSource1.SelectCommand = "select * from table order by id";
    }
    protected void sqlcommandone()
    {
    SqlDataSource1.SelectCommand = "select top 1 * from table order by id";
    }
