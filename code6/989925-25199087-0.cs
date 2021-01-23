    class ListViewItemComparer : IComparer
    {
    	public SortOrder Order = SortOrder.Ascending;
    	public int Column;
    
    	public ListViewItemComparer()
    	{
    		Column = 0;
    	}
    	public ListViewItemComparer(int column)
    	{
    		Column = column;
    	}
    	public int Compare(object x, object y)
    	{
    		int returnVal = String.Compare(((ListViewItem)x).SubItems[Column].Text,
    		((ListViewItem)y).SubItems[Column].Text);
    
    		if (Order == SortOrder.Descending)
    			return -returnVal;
    		else
    			return returnVal;
    	}
    }
