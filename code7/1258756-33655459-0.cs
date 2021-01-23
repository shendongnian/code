    class Window1: Window {
        private readonly ObservableCollection<MyDataItem> _children;
        private readonly CollectionViewSource _viewSource;
        public Window1()
        {
            // ... 
            _children = new ObservableCollection<MyDataItem>();
            _viewSource = new CollectionViewSource
            {
                Source = _children
            };
            myListView.ItemsSource = _viewSource;
            // ...
        }
        // This method needs to be called when your checkbox state is modified.
        // "filter = null" means no filter
        public void ApplyFilter(Func<MyDataItem, bool> filter)
        {
            if (_viewSource.View.CanFilter)
            {
                _viewSource.View.Filter = (filter == null) ? (o => true): (o => filter((MyDataItem) o));
            }
        }
