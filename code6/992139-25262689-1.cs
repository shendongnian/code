    public Order SelectedOrder
    {
        get { return selectedOrder; }
        set
        {
            selectedOrder = value;
            NotifyPropertyChanged("SelectedOrder");
            selectedOrder.PropertyChanged += Item_PropertyChanged;
        }
    }
...
    private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "SomeProperty")
        {
            // Do something here with SelectedOrder and SelectedOrder.SomeProperty here
        }
    }
