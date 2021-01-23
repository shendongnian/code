    protected void GridView1_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // this assumes the drop-down-list columns are the first, second, and third columns (ordinal positions 0, 1, and 2)
            DropDownList ddl1, ddl2, ddl3;
            ddl1 = (DropDownList)e.Row.Cells[0].Controls[0];
            ddl2 = (DropDownList)e.Row.Cells[1].Controls[0];
            ddl3 = (DropDownList)e.Row.Cells[2].Controls[0];
            DataRow currentRow = (DataRow)e.Row.DataItem;
            ddl1.SelectedValue = currentRow[0].ToString();
            ddl2.SelectedValue = currentRow[1].ToString();
            ddl3.SelectedValue = currentRow[2].ToString();
        }
    }
