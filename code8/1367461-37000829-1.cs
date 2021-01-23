    public ObservableCollection<Message> messagelist;
    public ObservableCollection<MyLanguage> languagelist = new ObservableCollection<MyLanguage>();
    
    public MainPage()
    {
        this.InitializeComponent();
        messagelist = new ObservableCollection<Message>();
    }
    
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        //add data to messagelist
        languagelist.Clear();
        languagelist.Add(new MyLanguage { language = "English" });
        languagelist.Add(new MyLanguage { language = "Arabic" });
    }
