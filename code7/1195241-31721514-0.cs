    protected void grdYourGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {   
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Attaching one onclick event for the entire row, so that it will
            // fire SelectedIndexChanged, while we click anywhere on the row.
            e.Row.Attributes["onclick"] = 
              ClientScript.GetPostBackClientHyperlink(this.grdYourGrid, "Select$" + e.Row.RowIndex);
        }
    }
