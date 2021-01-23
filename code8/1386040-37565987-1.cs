	private CollectionView _collectionView = null;
	public CollectionView CollectionView
	{
		get
		{
			_collectionView = (CollectionView)CollectionViewSource.GetDefaultView(EntityCollection);
			if (_collectionView != null)
				_collectionView.SortDescriptions.Add(new SortDescription("PropertyName", ListSortDirection.Ascending));
			return _collectionView;
		}
	}
