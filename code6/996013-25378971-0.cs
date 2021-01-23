    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    	if (e.Row.RowType == DataControlRowType.DataRow)
    	{
    		AjaxControlToolkit.Rating star = (AjaxControlToolkit.Rating)e.Row.FindControl("rate2");
    		star.CurrentRating = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Rating"));
    
    	}
    }
