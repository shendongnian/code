    public ICollectionView Data { get; private set; }
    ...
    // Create default view for the list
    Data = CollectionViewSource.GetDefaultView(list);
    // Set filter delegate for CollectionView
    Data.Filter = FilterData;
            
    ....
    private bool FilterData(object obj)
    {
            DataContainer cont = (DataContainer)obj;
            return string.IsNullOrEmpty(FilterText) || cont.Name.StartsWith(FilterText, StringComparison.OrdinalIgnoreCase);
    }
    private string myfiltertext;
    public string FilterText
    {
        get { return myfiltertext; }
        set
        {
            myfiltertext = value;
            // Refresh collection view after Filter text modification
            Data.Refresh();
        }
    }
