    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable oDT = new DataTable();
        oDT.Columns.Add("edit",typeof(string));
        oDT.Columns.Add("LastName", typeof(string));
        oDT.Rows.Add("ad", "1212121");
        oDT.Rows.Add("aad", "1asdasd212121");
        GridView2.DataSource = oDT;
        GridView2.DataBind();      
    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridView2.SelectedRow;
        TextBox1.Text = row.Cells[1].Text;
    }
