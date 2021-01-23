    protected void grdCreateGroup_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                if (e.CommandName == "sendInvite")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = grdCreateGroup.Rows[index];
                    
                      Button b = (Button)row.FindControl("btnSendInvite");
                       b.Text = row.Cells[0].Text;
    
                }
    }
