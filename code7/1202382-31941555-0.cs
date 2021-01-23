    public SomeDataType SelectedItem
    {
    	get { return selectedItem; }
    	set
    	{
    		selectedItem = value;
    		NotifyPropertyChanged("SelectedItem");
    		DoSomethingWithSelectedValue(SelectedItem);
    	}
    }
