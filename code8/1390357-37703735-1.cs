    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindSimpleGrid();
        }
    }
    private void BindSimpleGrid()
    {
        var items = 
            new List<string>{ "Item 0", "Item 1", "Item 2", "Item 3", "Item 4"};
        SimpleGrid.DataSource = items;
        SimpleGrid.DataBind();
    }
