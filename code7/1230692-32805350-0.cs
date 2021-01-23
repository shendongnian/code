    protected void Page_Load(object sender, EventArgs e)
    {
        if(!this.IsPostBack)
        {
            this.ColumnsList.Items.Add(new ListItem { Text= "Text1",  Value = "value1" });
            this.ColumnsList.Items.Add(new ListItem { Text = "Text2", Value = "value2" }); 
            this.ColumnsList.Items.Add(new ListItem { Text = "Text3", Value = "value3" });
            this.ColumnsList.Items.Add(new ListItem { Text = "Text4", Value = "value4" });
        }
    }
