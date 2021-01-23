    public class ItemData
    {
    	public string ItemName { get; set; }
    	public int CopyNumber { get; set; }
    	public Guid Guid { get; set; }
    	public DateTime Date { get; set; }
    	public string BestSeller { get; set; }
    	public string Category { get; set; }
    	public string Subcategory { get; set; }
    }
	
    ItemData row = new ItemData { 
        		// set each property value 
        	};
    ListViewItem _listViewItem = new ListViewItem();
    _listViewItem.Content = row;
    LibraryList.Items.Add(_listViewItem.Content); // not sure if you need content here
