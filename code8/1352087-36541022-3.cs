    private ObservableCollection<Menu> menu = new ObservableCollection<Menu>();
    
    public MainPage()
    {
        this.InitializeComponent();
    }
    
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        menu.Clear();
        menu.Add(new Menu { Link = typeof(Link1), Name = typeof(Link1).Name });
        menu.Add(new Menu { Link = typeof(Link2), Name = typeof(Link2).Name });
        menu.Add(new Menu { Link = typeof(Link3), Name = typeof(Link3).Name });
    }
