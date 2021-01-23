    public string NewItem { get; set+notify; }
    ctor(){
        myCollection = new ObservableCollection<T>();
        myCollection.CollectionChanged += OnMyCollectionChanged;
    }
    private void OnMyCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
    {
        if (args.Action == NotifyCollectionChangedAction.Add){
            var last = args.NewItems.FirstOrDefault();
            if (last == null) return;
            NewItem = last.Value;
        }
    }
    //XAML:
    <TextBox Text="{Binding NewItem, Mode=OneWay}" />
