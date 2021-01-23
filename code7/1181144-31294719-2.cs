    protected void MergeGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowIndex == 0) //Select the row
            {
                e.Row.BackColor = System.Drawing.Color.FromArgb(255, 0, 0);
                
                //or you can select the color
                //e.Row.BackColor = System.Drawing.Color.Red;
            }
        }
    }
