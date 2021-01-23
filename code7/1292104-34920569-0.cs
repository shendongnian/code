    private object selectedItem;
	public object SelectedItem
	{
		get { return selectedItem; }
		set
		{
			selectedItem = value;
			OnPropertyChanged("SelectedItem");
		}
	}
