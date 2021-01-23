    protected void gvTrades_DataBound(object sender, EventArgs e)
    {
        int myIndex = 0;
        foreach (DataControlFieldHeaderCell headerCell in gvTrades.HeaderRow.Cells)
        {
            if (headerCell.Text == "MyColumnName")
                break;
            myIndex++;
        }
        if (myIndex <= gvTrades.HeaderRow.Cells.Count - 1)
        {
            foreach (GridViewRow row in gvTrades.Rows)
            {
                row.Cells[myIndex].Text = String.Format("{0}%", row.Cells[myIndex].Text);
            }
        } 
    }
