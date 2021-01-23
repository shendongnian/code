    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
            if (e.CommandName == "removethis")
            {
               GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
               row.Visible = false;
            }
    }
