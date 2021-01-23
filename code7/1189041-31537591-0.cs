    private static ObservableCollection<DataRowView> _dataGridSrcCollection = new ObservableCollection<DataRowView>();
    public static ObservableCollection<DataRowView> DataGridSrcCollection
    {
        get
        {
            return _dataGridSrcCollection;
        }
        set
        {
            if (value != _dataGridSrcCollection)
            {
                if (_dataGridScrCollection != null)
                {
                    _dataGridScrCollection.CollectionChanged -= DataGridScrCollection_CollectionChanged;
                    foreach (var row in _dataGridScrCollection)
                        row.PropertyChanged -= DataRowView_PropertyChanged;
                }
                if (value != null)
                {
                    value.CollectionChanged += DataGridScrCollection_CollectionChanged;
                    foreach (var row in value)
                        row.PropertyChanged += DataRowView_PropertyChanged;
                }
                _dataGridSrcCollection = value;        
            }  
        }
    }
    private void DataGridScrCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.OldItems != null)
            foreach (var item in e.OldItems)
                ((DataRowView)item).PropertyChanged -= DataRowView_PropertyChanged;
        if (e.NewItems != null)
            foreach (var item in e.NewItems)
                ((DataRowView)item).PropertyChanged += DataRowView_PropertyChanged;
    }
    private void DataRowView_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        // This will be called every time a change is made to any cell
    }
