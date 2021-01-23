    class ViewModel
    {
        public ViewModel()
        {
            Items = new ObservableCollection<Item>();
            PropertyChangedEventHandler propertyChangedHandler = (o, e) =>
            {
                if (e.PropertyName == nameof(Item.IsChecked))
                    OnPropertyChanged(nameof(IsButtonEnabled));
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
        }
    
        public ObservableCollection<Item> Items { get; }
    
        public bool IsButtonEnabled => Items.Any(i => i.IsChecked);
    }
