    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ObservableCollection<FirstViewModel> _items;
        private readonly ICommand _addFirstFirstChildCommand;
        private readonly ICommand _addSecondFirstChildCommand;
        private readonly ICommand _toggleExpandCollapseCommand;
        private bool _firstAddedFlag;
        public MainViewModel(IEnumerable<First> records)
        {
            _items = new ObservableCollection<FirstViewModel>();
            foreach(var r in records)
            {
                _items.Add(new FirstViewModel(r));
            }
            _addFirstFirstChildCommand = new RelayCommand(param => AddFirst(), param => CanAddFirst);
            _addSecondFirstChildCommand = new RelayCommand(param => AddSecond(), param => CanAddSecond);
            _toggleExpandCollapseCommand = new RelayCommand(param => ExpandCollapseAll(), param =>
            {
                return true;
            });
        }
        public ObservableCollection<FirstViewModel> Items
        {
            get
            {
                return _items;
            }
        }
        public ICommand AddFirstFirstChildCommand
        {
            get
            {
                return _addFirstFirstChildCommand;
            }
        }
        public ICommand AddSecondFirstChildCommand
        {
            get
            {
                return _addSecondFirstChildCommand;
            }
        }
        public ICommand ToggleExpandCollapseCommand
        {
            get
            {
                return _toggleExpandCollapseCommand;
            }
        }
        public bool CanAddFirst
        {
            get
            {
                return true;
            }
        }
        public bool CanAddSecond
        {
            get
            {
                //Only allow second to be added if we added to first, first
                return _firstAddedFlag;
            }
        }
        public void AddFirstChild(FirstViewModel item)
        {
            Items.Add(item);
        }
        private void AddFirst()
        {
            _items[0].AddChild(new Second(10));
            _firstAddedFlag = true;
        }
        private void AddSecond()
        {
            _items[1].AddChild(new Second(20));
        }
        private void ExpandCollapseAll()
        {
            foreach(var i in Items)
            {
                i.IsExpanded = !i.IsExpanded;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
-----
    public class FirstViewModel : INotifyPropertyChanged
    {
        private readonly First model;
        private readonly ObservableCollection<SecondViewModel> _children;
        private bool _isExpanded;
        public FirstViewModel(First first)
        {
            _children = new ObservableCollection<SecondViewModel>();
            model = first;
            foreach(var s in first.Children)
            {
                Children.Add(new SecondViewModel(s));
            }
            model.ChildAdded += OnChildAdded;
        }
        public string FirstName
        {
            get
            {
                return model.Name;
            }
            set
            {
                model.Name = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<SecondViewModel> Children
        {
            get
            {
                return _children;
            }
        }
        public bool IsExpanded
        {
            get
            {
                return _isExpanded;
            }
            set
            {
                _isExpanded = value;
                NotifyPropertyChanged();
            }
        }
        internal void AddChild(Second second)
        {
            model.AddChild(second);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void OnChildAdded(object sender, ChildAddedEventArgs args)
        {
            if(Children != null)
            {
                Children.Add(new SecondViewModel(args.ChildAdded));
            }
        }
    }
