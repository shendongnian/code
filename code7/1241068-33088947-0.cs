    class ViewModel
    {
        private class AddCommandObject : ICommand
        {
            private readonly ViewModel _target;
            public AddCommandObject(ViewModel target)
            {
                _target = target;
            }
            public bool CanExecute(object parameter)
            {
                return true;
            }
            public event EventHandler CanExecuteChanged;
            public void Execute(object parameter)
            {
                _target.AddContentItem();
            }
        }
        private class RemoveCommandObject : ICommand
        {
            private readonly ViewModel _target;
            public RemoveCommandObject(ViewModel target)
            {
                _target = target;
            }
            public bool CanExecute(object parameter)
            {
                return true;
            }
            public event EventHandler CanExecuteChanged;
            public void Execute(object parameter)
            {
                _target.RemoveContentItem((TabItem)parameter);
            }
        }
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
            _addCommand = new AddCommandObject(this);
            _removeCommand = new RemoveCommandObject(this);
        }
        public void AddContentItem()
        {
            TabItems.Add(new TabItem { Header = "Three", Content = DateTime.Now.ToLongDateString() });
        }
        public void RemoveContentItem(TabItem item)
        {
            TabItems.Remove(item);
        }
    }
