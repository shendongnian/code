    public List<ListViewItem> getSortedListView()
    {
        ListView lvLocations = new ListView();
        lvLocations.ListViewItemSorter = new ListViewItemComparer();
    
        // Reads CSV file to get required location. 
        // lvGlobalLocations is filled with every location on the system.
    	
    	var list = new List<ListViewItem>(lvGlobalLocations.Items.Where(item => item.Text == <location name>))
    	list.Sort((a, b) => a.Whatever.CompareTo(b.Whatever));
    	return list;
    }
