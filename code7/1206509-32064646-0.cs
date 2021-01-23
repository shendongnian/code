	private ViewModelItemType _ViewModelItem;
	public ViewModelItemType ViewModelItem
	{
		get
		{
			return this._ViewModelItem;
		}
		set
		{
			this._ViewModelItem = value;
			RaisePropertyChanged(() => this.ViewModelItem);
		}
	}
    public ICommand EditCommand { get { return new RelayCommand<ViewModelItemType>(OnEdit); } }
	private void OnEdit(ViewModelItemType itemToEdit)
	{
		... do something here...
	}
