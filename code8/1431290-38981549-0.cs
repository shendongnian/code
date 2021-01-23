    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            ddlFood.Items.Add(new ListItem { Text = "Fruits", Value = "1" });
            ddlFood.Items.Add(new ListItem { Text = "Vegetables", Value = "2" });
            ddlFood.Items.Add(new ListItem { Text = "Meat", Value = "3" });
        }
    }
    protected void btnDone_Click(object sender, EventArgs e)
    {
        System.Diagnostics.Debugger.Break();
        string favFood = ddlFood.SelectedItem.Text;
    }
