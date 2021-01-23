    public List<string> dep { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            dep = new List<string> { "Item 1", "Item 2", "Item 3" };
            Repeater1.DataSource = dep;
            Repeater1.DataBind();
        }
    }
    protected void delete_button(object sender, CommandEventArgs e)
    {
        string text = e.CommandArgument.ToString();
    }
