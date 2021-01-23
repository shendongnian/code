       protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[GetColumnIndexByName(e.Row, "yourDate")].ForeColor  = System.Drawing.Color.Red ;
        }
    }
