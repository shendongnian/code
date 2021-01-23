    protected void Page_PreRender(object sender, EventArgs e)
    {
        Panel.Visible = GridView.Rows.Count > 0;
    }
    protected void GridView_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridView.DataBind();
        Panel.Visible = GridView.Rows.Count > 0;
    }
    protected void GridView_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        GridView.DataBind();
        Panel.Visible = GridView.Rows.Count > 0;
    }
