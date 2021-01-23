    public MainPage()
    {
        InitializeComponent();
        List<string> items = new List<string>();
        items.Add(AppResources.OptionOne);
        items.Add(AppResources.OptionTwo);
        items.Add(AppResources.OptionThree);
        items.Add(AppResources.OptionFour);
        items.Add(AppResources.OptionFive);
        lstClubsPick.ItemsSource = items;
    }
