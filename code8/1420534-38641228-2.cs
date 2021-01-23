    protected void gvFAQ_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddl = e.Row.FindControl("DropDownList1") as DropDownList;
            ddl.Enabled = e.Row.RowIndex == gvFAQ.EditIndex;
        }
    }
