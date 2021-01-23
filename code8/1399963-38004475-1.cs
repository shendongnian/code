    protected void gridview_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       if (e.CommandName == "Del") {
                //Get Command Argument
                int IdToDelete = Convert.ToInt32( e.CommandArgument.ToString());
                //Your Delete Command
                //Rebind GridView
            }
    }
