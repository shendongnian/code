    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        //GridView1.DataBind(); this is meaningless, you have not set a DataSource
        BindGrid();
    }
