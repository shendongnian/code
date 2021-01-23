    protected void grdEmployees_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       if (e.Row.RowType == DataControlRowType.DataRow)
       {
           if (e.Row.RowState && DataControlRowState.Edit > 0)
           {
               DropDownList ddList= (DropDownList)e.Row.FindControl("ddlEvents");
               //Now call your ADO.NET code and bind the dropdownlist.
           }
    }
