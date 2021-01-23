    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[2].Text == "Youvalue") //condition here
            {
                 e.Row.BackColor = System.Drawing.Color.Yellow;
            }
         }
    }
