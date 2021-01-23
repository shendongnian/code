    protected void myListDropDown_Change(object sender, EventArgs e)
        {
           
            if (ddlDate.SelectedValue == "Weekly")
            {
                litInfo.Text= weekly();
                
    
            }
            else if (ddlDate.SelectedValue == "Monthly")
            {
                litInfo.Text=monthly();
               
    
            }
    
        }
