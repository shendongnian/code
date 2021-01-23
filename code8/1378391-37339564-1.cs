    private ObservableCollection<EquipmentType> list = new ObservableCollection<EquipmentType>();
    
    public MainPage()
    {
        this.InitializeComponent();
    }
    
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        list.Add(new EquipmentType { Count = 0 });
        list.Add(new EquipmentType { Count = 1 });
        list.Add(new EquipmentType { Count = 0 });
        list.Add(new EquipmentType { Count = 0 });
        list.Add(new EquipmentType { Count = 1 });
        list.Add(new EquipmentType { Count = 1 });
    }
