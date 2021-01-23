    protected void CustomersGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int index = Convert.ToInt32(e.CommandArgument);
           ((Label)grdCustomer.Rows[index].FindControl("lblEmployeeId")).Visible = true;  
           ((Label)grdCustomer.Rows[index].FindControl("txtEmployeeName")).Visible = true;
        }
    }
