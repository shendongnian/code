    public DataGrid_UC(IEnumerable<object> allObjects, int? entriesPerPage = null)
    {
        InitializeComponent();
        AllObjects = new ObservableCollection<object>(allObjects);
        ...
    }
