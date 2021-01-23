    private ObservableCollection<Menu> menu = new ObservableCollection<Menu>();
    
    public MainPage()
    {
        this.InitializeComponent();
    }
    
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        menu.Clear();
        menu.Add(new Menu { Link = typeof(Link1) });
        menu.Add(new Menu { Link = typeof(Link2) });
        menu.Add(new Menu { Link = typeof(Link3) });
    }
 
