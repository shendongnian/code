    protected void MergeGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowIndex == 0)
            {
                e.Row.BackColor = System.Drawing.Color.FromArgb(255, 0, 0);
            }
        }
    }
