    Items = new ObservableCollection<Item>();
    PropertyChangedEventHandler propertyChangedHandler = (o, e) =>
    {
        if (e.PropertyName == nameof(Item.IsVisible))
            OnPropertyChanged(nameof(IsVisible));
    };
    
    Items.CollectionChanged += (o, e) =>
    {
        if (e.OldItems != null)
            foreach (var item in e.OldItems.OfType<INotifyPropertyChanged>())
                item.PropertyChanged -= propertyChangedHandler;
        if (e.NewItems != null)
            foreach (var item in e.NewItems.OfType<INotifyPropertyChanged>())
                item.PropertyChanged += propertyChangedHandler;
    };
