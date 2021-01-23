    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        ListBox1.DataSource = <your datasource>
        ListBox1.DataBind();
      }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
      GridView2.DataSource = ListBox1.Items
                               .Cast<ListItem>()
                               .Where(li => li.Selected == true)
                               .ToArray();
      GridView2.DataBind();
    }
