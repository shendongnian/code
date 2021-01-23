    private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
    {
    	ListViewItemComparer comparer = (ListViewItemComparer)listView1.ListViewItemSorter;
    
    	if (e.Column == comparer.Column)
    	{
    		comparer.Order = Swap(comparer.Order);
    	}
    	else
    	{
    		comparer.Order = SortOrder.Ascending;
    	}
    
    	comparer.Column = e.Column;
    	listView1.Sort();
    }
