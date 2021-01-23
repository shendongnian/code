    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "xxx")
        {
            // Why LinkButton because your button type is LinkButton...
            GridViewRow gvr = ((LinkButton)e.CommandSource).NamingContainer as LinkButton;
            int rowIndex = gvr.RowIndex;
        }
    }
