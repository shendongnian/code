	public ICommand OkCommand { get { return new RelayCommand(Ok); } }
	protected virtual void Ok()
	{
		// ... do something ...
	}
