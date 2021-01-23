    public MainPage() {
        this.InitializeComponent();
        HamburgerListItemCommand = new Command<object>(HamburgerListButtonClick); 
    }
    private void HamburgerListButtonClick(object parameter) {
        AzureDataItem item = parameter as AzureDataItem;
        // Now you have access to the clicked item
        int index = DefaultViewModel.IndexOf(item);
    }
