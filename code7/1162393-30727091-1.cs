     protected void grvContact_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                GridViewRow row = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                if (row != null)
                {
                    lblContactID.Text = row.Cells[0].Text;
                    txtFirstName.Text = row.Cells[1].Text;
                    txtLastName.Text = row.Cells[2].Text;
                }
    
            }
        }`
