    protected void GrdV_Projects_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRow row = ((DataRowView)e.Row.DataItem).Row;
            DateTime renewalDate = row.Field<DateTime>("RenewalDate");
            if (renewalDate.Date > DateTime.Today)
                e.Row.Cells[7].BackColor = System.Drawing.Color.Red;
            else
                e.Row.Cells[7].BackColor = System.Drawing.Color.Green;
        }
    }
