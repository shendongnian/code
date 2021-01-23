    private ObservableCollection<Item> mItems;
    public ICollectionView MyView { get; private set; }
    public MyVM()
    {
        mItems = new ObservableCollection<Item>();
        ListCollectionView myView = new ListCollectionView(mItems);
        // Do whatever you want with the view here
        MyView = myView;
    }
