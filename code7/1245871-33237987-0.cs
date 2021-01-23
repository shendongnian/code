    class MainWindowViewModel
    {
        private Customer client = new Customer();
	public Customer Client{get;set;}
        public MainWindowViewModel()
        {
            client.Name = "Greg Johnson";
            client.Friends = new ObservableCollection<string>() { "Leslie", "Mitch" };
        }
    }
