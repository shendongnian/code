    protected void DocNameClick(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        GridViewRow row = (GridViewRow) btn.NamingContainer;
        // use row.FindControl("ControlID") to get controls in other columns ...
        int rowIndex = row.RowIndex;
        string name = btn.Text;
    }
