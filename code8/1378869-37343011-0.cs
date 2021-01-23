    protected void DocNameClick(object sender, System.EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        //Get the row that contains this button
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
    }
