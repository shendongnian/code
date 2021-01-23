	public void InitializeItems(int count)
	{
		var items = new List<string>(count);
		for (int i = 0; i < count; i++)
			items.Add("Item " + i);
		PlaylistItems = new ObservableCollection<string>(items);
	}
