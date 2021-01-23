	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			(((System.Web.UI.WebControls.WebControl)e.Row.Cells[0].Controls[0])).ToolTip = "My beautiful button";
        }
	}
