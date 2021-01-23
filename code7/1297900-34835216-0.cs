    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    	{
    		if (e.Row.RowType == DataControlRowType.DataRow)
    		{
               //Process like you do in your method
            }
    		if (e.Row.RowType == DataControlRowType.Footer)
    		{
    			Label lblSum1 = (Label)e.Row.FindControl("lblTotalqty");
    			lblSum1.Text = Sum1.ToString();
    		}
        }
