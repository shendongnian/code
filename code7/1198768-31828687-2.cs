    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[ReasonCellNumber].Text == "Reason")
            {
                e.Row.Visible = false;
            }
        }
    }
