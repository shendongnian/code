    protected void gvInfo_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                if (e.CommandName == "UpdateData")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvInfo.Rows[index];
    
                       string cellText = row.Cells[0].Text;
    
                }
    }
