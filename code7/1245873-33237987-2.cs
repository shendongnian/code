    class MainWindowViewModel
    {
	    public Customer Client { get; set; }
        public MainWindowViewModel()
        {
            Client = new Customer();
            Client.Name = "Greg Johnson";
            Client.Friends = new ObservableCollection<string>() { "Leslie", "Mitch" };
        }
    }
