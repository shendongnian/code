    class ViewModel
    {
        private ObservableCollection<TabItem> tabItems;
        public ObservableCollection<TabItem> TabItems
        {
            get { return tabItems ?? (tabItems = new ObservableCollection<TabItem>()); }
        }
        public ICommand AddCommand { get { return _addCommand; } }
        public ICommand RemoveCommand { get { return _removeCommand; } }
        private readonly ICommand _addCommand;
        private readonly ICommand _removeCommand;
        public ViewModel()
        {
            TabItems.Add(new TabItem { Header = "One", Content = DateTime.Now.ToLongDateString() });
            TabItems.Add(new TabItem { Header = "Two", Content = DateTime.Now.ToLongDateString() });
            TabItems.Add(new TabItem { Header = "Three", Content = DateTime.Now.ToLongDateString() });
            // Use a lambda delegate to map the required Action<T> delegate
            // to the parameterless method call for AddContentItem()
            _addCommand = new DelegateCommand<object>(o => this.AddContentItem());
            // In this case, the target method takes a parameter, so we can just
            // use the method directly.
            _removeCommand = new DelegateCommand<TabItem>(RemoveContentItem);
        }
