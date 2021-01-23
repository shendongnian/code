	public ICommand OpenClientCommand { get { return new RelayCommand<Client>(OnOpenClient); } }
	private void OnOpenClient(Client client)
	{
		// ... do something with client ...
	}
