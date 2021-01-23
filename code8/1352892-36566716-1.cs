    class ListItem
    {
        public int Id { get; set; }
        public string Text { get; set; }
        private bool _isChecked;
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                if (IsChecked)
                    _parent.ListItemsToDelete.Add(Item);
                else
                    _parent.ListItemsToDelete.Remove(Item);
                RaisePropertyChanged(() => IsChecked);
            }
        }
        readonly MyListViewModel _parent;
        public ListItem(MyListViewModel parent)
        {
            _parent = parent;
        }
    }
