    private ICommand _itemSelection;
    public ICommand ItemSelection => _itemSelection ?? (_itemSelection = new DelegateCommand(_ => MessageBox.Show("Click")));
    public MainWindow()
    {
        Items.Add(new SelectableObject("Item 1"));
        Items.Add(new SelectableObject("Item 2"));
        Items.Add(new SelectableObject("Item 3"));
        InitializeComponent();
        DataContext = this;
    }
    public ObservableCollection<SelectableObject> Items { get; } = new ObservableCollection<SelectableObject>(); 
