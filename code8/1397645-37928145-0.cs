    // Create property
    public ObservableCollection<IMarketDataViewModel> MarketDataItems { get; private set; }
    ...
    // Create Binding
    Binding bindingObject = new Binding("MarketDataItems");
    bindingObject.Source = this; //codebehind class instance which has MarketDataItems
    marketDataTreeView.SetBinding(TreeView.ItemsSource, bindingObject);
