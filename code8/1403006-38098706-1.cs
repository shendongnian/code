    public ObservableCollection<Item> Items = ... // bind ItemsControl.ItemsSource to this
    class Item : INotifyPropertyChanged
    {
        bool _isExpanded;
        public bool IsExpanded // bind Expander.IsExpanded to this
        {
            get { return _isExpanded; }
            set
            {
                Data = value ? new SubItem(this) : null;
                OnPropertyChanged(nameof(Data));
            }
        }
        public object Data {get; private set;} // bind item Content to this
    }
    public SubItem: INotifyPropertyChanged { ... }
