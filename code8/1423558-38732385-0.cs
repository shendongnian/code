    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            PopulateDropdown();
    }
    
    private void PopulateDropdown()
    {
        myDdl.Items.Clear();
        var array1 = new ListItem[3];
        array1[0] = new ListItem("item1", "item1");
        array1[1] = new ListItem("item2", "item2");
        array1[2] = new ListItem("item3", "item3");
        myDdl.Items.AddRange(array1);
        myDdl.DataBind();
    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        var selectedVal = myDdl.SelectedValue;
    }
    
    protected void myDdlChange(object sender, EventArgs e)
    {
        
    }
