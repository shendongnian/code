    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // searching through the rows
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int reading = Convert.ToInt32(((HiddenField)e.Row.FindControl("readStatusHiddenField")).Value);
            if (reading == 0)
            {
                e.Row.BackColor = Color.LightGray;
                e.Row.Font.Bold = true;
            }
        }
    }
