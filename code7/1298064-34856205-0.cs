    protected void gvwSales_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    	if (e.Row.RowType == DataControlRowType.DataRow)
    	{
    		decimal tmptotalsales = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "totalsales").ToString());
    		GrandTotalSales += tmptotalsales; 
    	}      
    	if (e.Row.RowType == DataControlRowType.Footer)
    	{
    		e.Row.Cells[0].Font.Bold = true;
    		e.Row.Cells[3].Font.Bold = true;
    		e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
    		e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
    		e.Row.Cells[0].Text = "Total Sales";
    		e.Row.Cells[3].Text = GrandTotalSales.ToString("F");
    	}
    }
