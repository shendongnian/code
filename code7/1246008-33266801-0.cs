    if ((gd.Cells[0].FindControl("chkCheck") as CheckBox).Checked)
     {
            // Step 1: Access the Control inside Cell
                Label lblName = (Label)gd.Cells[1].FindControl("lblStudName");
             // Step 2: Access the Value from Control in step 1
                string Name = lblName.Text;
       
        // Combine Step 1 & Step 2: Access Values in one line
        string Name = ((Label)gd.Cells[1].FindControl("lblStudName")).Text;
        string firstName = ((Label)gd.Cells[2].FindControl("lblFirstName")).Text;
        
        // ....same way for all Columns which use a <asp:TemplateField>
    
    }
