    private ObservableCollection<TabItem> families;
    public ObservableCollection<TabItem> Families
    {
        get { return families ?? (families = new ObservableCollection<Families>()); }
    }  
