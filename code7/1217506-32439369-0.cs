        // add static field to hold selected Item
        public static TreeViewItemViewModel SelectedChild { get; set; }
        public TreeViewItemViewModel Parent{ get; private set;}
        public string ChildName { get; set; }
        public object DataSource { get; set; }
        private readonly ObservableCollection<TreeViewItemViewModel> _children;
        public ObservableCollection<TreeViewItemViewModel> Children
        {
            get
            {
                return _children;
            }
            
        }
        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected == value) return;
                if (SelectedChild != null)
                {
                    SelectedChild.IsSelected = false;
                    SelectedChild = null;
                }
                _isSelected = value;
                if (_isSelected)
                    SelectedChild = this;
                // NotifyPropertyChanged
            }
        }
        public TreeViewItemViewModel(string name, object myObj, TreeViewItemViewModel parent)
        {
            ChildName = name;
            DataSource = myObj;
            Parent = parent;
            _children = new ObservableCollection<TreeViewItemViewModel>();
        }
        public override string ToString()
        {
            return ChildName;
        }
        protected virtual void InitChild()
        {
            
        }
        public void DeleteItem(TreeViewItemViewModel myTreeViewItem)
        {
            Children.Remove(myTreeViewItem);
        }
        public static void DeleteSelectedItem()
        {
            if (SelectedChild != null && SelectedChild.Parent != null)
            {
                SelectedChild.Parent.DeleteItem(SelectedChild);
            }
        }
    }
