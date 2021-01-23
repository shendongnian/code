    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRow")
        {
            int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
            GridView1.EditIndex = rowIndex;
            BindGrid();
        }
        else if (e.CommandName == "DeleteRow")
        {
            BAL.bal.DeleteCustomers(Convert.ToInt32(e.CommandArgument));
            BindGrid();
        }
        else if (e.CommandName == "CancelUpdate")
        {
            GridView1.EditIndex = -1;
            BindGrid();
        }
        else if (e.CommandName == "UpdateRow")
        {
            int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
    
            int CustomerId = Convert.ToInt32(e.CommandArgument);
            string Name = ((TextBox)GridView1.Rows[rowIndex].FindControl("TextBox1")).Text;
            string Gender = ((DropDownList)GridView1.Rows[rowIndex].FindControl("DropDownList1")).SelectedValue;
            string City = ((TextBox)GridView1.Rows[rowIndex].FindControl("TextBox3")).Text;
    
            BAL.bal.UpdateCustomers(CustomerId, Name, Gender, City);                    
            GridView1.EditIndex = -1;
            BindGrid();
        }
        else if (e.CommandName == "InsertRow")
        {
            string Name = ((TextBox)GridView1.FooterRow.FindControl("txtName")).Text;
            string Gender = ((DropDownList)GridView1.FooterRow.FindControl("ddlGender")).SelectedValue;
            string City = ((TextBox)GridView1.FooterRow.FindControl("txtCity")).Text;
    
            BAL.bal.InsertCustomers(name, gender, city);
                    
            BindGrid();
        }
    }
