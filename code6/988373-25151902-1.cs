	protected void gv_RowCreated(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.Header)
		{
			//Call the GetSortColumnIndex helper method to determine
			//the index of the column being sorted.
			int sortColumnIndex = GetSortColumnIndex();
			if (sortColumnIndex != -1)
			{
				// Call the AddSortImage helper method to add
				// a sort direction image to the appropriate
				// column header. 
				AddSortImage(sortColumnIndex, e.Row);
			}
		}
	}
	int GetSortColumnIndex()
	{
		// Iterate through the Columns collection to determine the index
		// of the column being sorted.
		foreach (DataControlField field in gv.Columns)
		{
			if (field.SortExpression == gv.SortExpression)
			{
				return gv.Columns.IndexOf(field);
			}
		}
		return -1;
	}
		void AddSortImage(GridViewRow headerRow) 
	{ 
		 int iCol = GetSortColumnIndex();
		 if (-1 == iCol) 
			   return; 
		 // Create the sorting image based on the sort direction.
		 Image sortImage = new Image();
		 if (SortDirection.Ascending == this.GridView1.SortDirection) 
	{             sortImage.ImageUrl = @"~\Images\BlackDownArrow.gif"; 
				   sortImage.AlternateText = "Ascending Order"; 
	}     else  
	{
				 sortImage.ImageUrl = @"~\Images\BlackUpArrow.gif";
				 sortImage.AlternateText = "Descending Order";
	}
		  // Add the image to the appropriate header cell. 
			headerRow.Cells[iCol].Controls.Add(new LiteralControl("&nbsp;"));
			headerRow.Cells[iCol].Controls.Add(sortImage); 
	} 
