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
	// This is a helper method used to add a sort direction
	// image to the header of the column being sorted.
	void AddSortImage(int columnIndex, GridViewRow headerRow)
