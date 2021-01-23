    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int colText = 1; //the index of the column you want to get the text
            int colButton = 0; //the index of the column of your button
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                (e.Row.Cells[colButton].Controls[0] as Button).Text = e.Row.Cells[colText].Text;
            }            
        }
