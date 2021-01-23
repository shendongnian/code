    protected void gvTrades_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Text = String.Format("{0}%", e.Row.Cells[0].Text);
        }
    }
