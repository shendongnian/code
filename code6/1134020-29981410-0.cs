    protected void gvReports_RowCreated(object sender, GridViewRowEventArgs e)
    {
    	if (e.Row.RowType == DataControlRowType.Header)
    	{
    		GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
    
    		int count = e.Row.Cells.Count;
    		TableHeaderCell cell = new TableHeaderCell();
    		cell.BorderWidth = 0;
    		cell.Text = "blah";
    		cell.ColumnSpan = count - 2;
    		row.Controls.Add(cell);
    		row.BackColor = ColorTranslator.FromHtml("#f5fafd");
    		gvReports.Controls[0].Controls.AddAt(0, row);
    	}
    }
