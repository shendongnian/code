      protected void gridinvoice_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            decimal Amount = 0;
        
            for (int y = 0; y < gridinvoice.Rows.Count; y++)
            {
                Amount += Convert.ToDecimal(gridinvoice.Rows[y].Cells[4].Text);
            }
        
            if (e.Row.RowType == DataControlRowType.Footer)
            {  
               Label lblamount = e.Row.FindControl("lblid") as Label;
               lblam.Text = Amount.ToString();
            }
        
        }
