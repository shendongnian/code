    public IEnumerable<Column> Columns { get; set; }
    public MainWindow()
    {
        Columns = GetColumns();
        InitializeComponent();
    }
    private IEnumerable<Column> GetColumns()
    {
        return Enumerable.Range(0, 5)
            .Select(x => new Column { Title = "Column " + x });
    }
