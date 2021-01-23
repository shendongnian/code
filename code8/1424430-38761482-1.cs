	public LoadFilesViewModel()
	{
		BrowseCommand = new RelayCommand(ExecuteBrowse, CanExecuteBrowse);
	}
	private void ExecuteBrowse()
	{
		// Do something 
	}
	private bool CanExecuteBrowse()
	{
		// Check if we are allowed to browser
		return true; // or false :)
	}
