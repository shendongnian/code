            public MainDataContext()
        {
            OnExpandedActionInViewModel = new Action<object, RoutedEventArgs>(OnExpanded);
        }
        public Action<object, RoutedEventArgs> OnExpandedActionInViewModel
        {
            get { return _onExpandedActionInViewModel; }
            private set
            {
                _onExpandedActionInViewModel = value;
                OnPropertyChanged();
            }
        }
