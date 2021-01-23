	public RelayCommand BrowseCommand
	{
		get;
		private set;
	}
	public LoadFilesViewModel()
	{
		BrowseCommand = new RelayCommand(executeBrowse, () => _canExecuteMyCommand);
	}
	private void executeBrowse()
	{
		// Do something 
	}
