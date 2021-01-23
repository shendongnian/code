    public MyControl()
    {
        // Bad pie!!
        SetValue(ItemsProperty, new ObservableCollection<Item>()); //overwrite default collection to avoid using the same one by all MyControls
        InitializeComponent();
        RootGrid.DataContext = this; //parent element
    }
    public MyControl()
    {
        InitializeComponent();
        Initialize(); // control is not yet loaded...
    }    
    
    protected void Initialize()
    { 
        Items = new ObservableCollection<Item>();
    }
