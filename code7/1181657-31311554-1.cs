    public static readonly DependencyProperty GridColumnsProperty = DependencyProperty.Register("GridColumns", typeof(ObservableCollection<DataGridColumn>), typeof(XGrid));
            public ObservableCollection<DataGridColumn> GridColumns
            {
                get { return (ObservableCollection<DataGridColumn>)GetValue(GridColumnsProperty); }
                set { SetValue(GridColumnsProperty, value); }
            }
    
    public XGrid()
    {
            GridColumns = new ObservableCollection<DataGridColumn>();
            GridColumns.CollectionChanged += (x, y) =>
                {
                    dataGrid.Columns.Clear();
                    foreach (var column in this.GridColumns)
                    {
                        dataGrid.Columns.Add(column);
                    }
                };
            InitializeComponent();
        }
