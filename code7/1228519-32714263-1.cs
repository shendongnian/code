    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }
    private void BindGrid()
    {
        // Get data from datasource and bind it to the gridview.
    }
    protected void id_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox lnkView = (sender as CheckBox);
        if (lnkView.Checked)
        {
             Response.Write( "you checked the checkbox");
        }
        else if (!lnkView.Checked)
        {
             Response.Write("checkbox is not checked");
        }
    }
        
    protected void lk_Click(object sender, EventArgs e)
    {
        LinkButton lnkView = (sender as LinkButton);
        GridViewRow row = (lnkView.NamingContainer as GridViewRow);
        string id = row.RowIndex.ToString();
        Response.Write("gridview clicked id is" + id);
    }
