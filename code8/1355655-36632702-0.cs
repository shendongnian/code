    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListBox1.DataSource = new List<ListItem>()
            {
                new ListItem("One", "1"),
                new ListItem("Two", "2"),
                new ListItem("Three", "3")
            };
            ListBox1.DataBind();
        }
    }
