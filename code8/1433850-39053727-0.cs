    if (e.Row.RowType == DataControlRowType.DataRow && gvCustomers.EditIndex == e.Row.RowIndex)
    {
        DropDownList ddltype = (DropDownList)e.Row.FindControl("ddltype");
        string query = "select distinct paymenttype from paymenttypes";
        SqlCommand cmd = new SqlCommand(query);
        ddltype.DataSource = GetData(cmd);
        ddltype.DataTextField = "type";
        ddltype.DataValueField = "type";
        ddltype.DataBind();
        ddltype.Items.FindByValue((e.Row.FindControl("Label31") as Label).Text).Selected = true;
    }
