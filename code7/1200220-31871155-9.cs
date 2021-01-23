     private ObservableCollection<MyCommandWrapper> _commandWrapperCollection = new ObservableCollection<MyCommandWrapper>();
    public ObservableCollection<MyCommandWrapper> MyCommands
        {
            get { return _commandWrapperCollection; }
            set
            {
                _commandWrapperCollection = value;
                OnPropertyChanged();
            }
        }
