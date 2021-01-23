    protected void myListDropDown_Change(object sender, EventArgs e)
        {
            DropDownList ctrl1 = FindControl("ddlDate") as DropDownList;
            if (ctrl1.SelectedValue == "Weekly")
            {
                litInfo.Text= weekly();
                
    
            }
            else if (ctrl1.SelectedValue == "Monthly")
            {
                litInfo.Text=monthly();
               
    
            }
    
        }
