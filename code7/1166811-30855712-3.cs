    private ObservableCollection<Item> mItems;
    public IEnumerable<Item> Items { get { return mItems; } }
    public MyVM()
    {
        mItems = new ObservableCollection<Item>();
    }
