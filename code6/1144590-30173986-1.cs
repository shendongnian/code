    private ObservableCollection<MenuItem> itemList
    public ObservableCollection<MenuItem> ItemList
    {
        get { return itemsList; }
        set
        {
            if (itemsList != value)
            {
                itemsList = value;
                OnPropertyChanged("ItemsList");
            }
        }
    }
