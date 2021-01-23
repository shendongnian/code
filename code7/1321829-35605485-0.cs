    public IEnumerable<ListViewItem> getSortedListView()
    {
        ListView lvLocations = new ListView();
        lvLocations.ListViewItemSorter = new ListViewItemComparer();
    
        // Reads CSV file to get required location. 
        // lvGlobalLocations is filled with every location on the system.
    
    	return lvGlobalLocations.Items.Where(item => item.Text == <location name>).OrderBy(x => x.Whatever);
    }
