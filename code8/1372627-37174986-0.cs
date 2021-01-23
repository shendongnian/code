    protected void GridViewName_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TableCell cell = e.Row.Cells[6];
            string Failures = cell.Text.ToString().Trim();
            string date = e.Row.Cells[5].ToString();
            if (Failures == "0" || Failures == "NULL")
            {
                cell.BackColor = Color.Green;
            }
            else
            {
                cell.BackColor = Color.Red;
            }
    
            DateTime dt;
            if (DateTime.TryParse(date, out dt))
            {
                e.Row.Cells[5].BackColor = Color.Red;
            }
    
        }
    }
