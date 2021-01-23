    protected void gridContributions_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {
             GridViewRow row = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
             string strFileName = ((LinkButton)row.FindControl("LinkButton1")).Text;
             ...
             ...
        }
    } 
