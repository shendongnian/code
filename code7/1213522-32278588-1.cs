    protected void grdViewCustomers_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string customerID = grdViewCustomers.DataKeys[e.Row.RowIndex].Value.ToString();
            GridView grdViewOrdersOfCustomer = (GridView)e.Row.FindControl("grdViewOrdersOfCustomer");
            grdViewOrdersOfCustomer.DataSource = SelectData("select * from [dbo].[View_Budget_Setup_2_Items] WHERE CUSID='" + customerID + "' order by id_item");
            grdViewOrdersOfCustomer.DataBind();
        }
    }
    protected void grdViewOrdersOfCustomer_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
           if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string ChildID = (GridView)sender.DataKeys[e.row.RowIndex].Value.ToString();
                string Editable = dbUtilities.SalesEditableID(ChildID);
                if (Editable == "Bud")
                {
                  // Set values here
                }
            }
    }
