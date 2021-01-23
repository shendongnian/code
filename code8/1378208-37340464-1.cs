    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRow")
        {
            int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
            GridView1.EditIndex = rowIndex;
            BindGridViewData();
        }
        else if (e.CommandName == "DeleteRow")
        {
            EmployeeDataAccessLayer.DeleteEmployee(Convert.ToInt32(e.CommandArgument));
            BindGridViewData();
        }
        else if (e.CommandName == "CancelUpdate")
        {
            GridView1.EditIndex = -1;
            BindGridViewData();
        }
        else if (e.CommandName == "UpdateRow")
        {
            int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
    
            int employeeId = Convert.ToInt32(e.CommandArgument);
            string name = ((TextBox)GridView1.Rows[rowIndex].FindControl("TextBox1")).Text;
            string gender = ((DropDownList)GridView1.Rows[rowIndex].FindControl("DropDownList1")).SelectedValue;
            string city = ((TextBox)GridView1.Rows[rowIndex].FindControl("TextBox3")).Text;
    
            EmployeeDataAccessLayer.UpdateEmployee(employeeId, name, gender, city);
                    
            GridView1.EditIndex = -1;
            BindGridViewData();
        }
        else if (e.CommandName == "InsertRow")
        {
            string name = ((TextBox)GridView1.FooterRow.FindControl("txtName")).Text;
            string gender = ((DropDownList)GridView1.FooterRow.FindControl("ddlGender")).SelectedValue;
            string city = ((TextBox)GridView1.FooterRow.FindControl("txtCity")).Text;
    
            EmployeeDataAccessLayer.InsertEmployee(name, gender, city);
                    
            BindGridViewData();
        }
    }
