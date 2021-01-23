	ObservableCollection<string> myCollection;
	ObservableCollection<string> MyCollectionViewProp
	{
		get
		{
			var tempCollection = new ObservableCollection<string>(myCollection);
			tempCollection.Add("Extra element");
			return tempCollection;
		}
	}
