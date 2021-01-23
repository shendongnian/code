    protected void myGridView_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                if (e.CommandName == "ApproveTransaction")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = gvInfo.Rows[index];
    
                    string cellText = row.Cells[2].Text;
    
                   //Update your data in database here and rebind the gridview to updated data
    
                }
    }
