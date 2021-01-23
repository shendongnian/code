    protected void grid_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
             DataRowView row = (DataRowView)e.Row.DataItem;
             decimal nonvat = (decimal)row["nonvat"];
             e.Row.Cells[0].Text = nonvat.ToString("#,##0.00;(#,##0.00);0}");
        }
    }
