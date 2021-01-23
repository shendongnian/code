	private ObservableCollection<Entity> _entityCollection = null;
	public ObservableCollection<Entity> EntityCollection
	{
		get
		{
			return _entityCollection;
		}
		set
		{
			_entityCollection = value;
			RaisePropertyChanged("EntityCollection");
			RaisePropertyChanged("CollectionView");
		}
	}
