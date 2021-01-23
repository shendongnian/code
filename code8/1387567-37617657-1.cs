    private void ClearSortDescriptionsOnItemsSourceChange()
    {
    	base.Items.SortDescriptions.Clear();
    	this._sortingStarted = false;
    	List<int> groupingSortDescriptionIndices = this.GroupingSortDescriptionIndices;
    	if (groupingSortDescriptionIndices != null)
    	{
    		groupingSortDescriptionIndices.Clear();
    	}
    	foreach (DataGridColumn column in this.Columns)
    	{
    		column.SortDirection = null;
    	}
    }
