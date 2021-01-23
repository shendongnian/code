     private ObservableCollection<MyCommandWrapper> _commandWrapperCollection = new ObservableCollection<MyCommandWrapper>();
    public ObservableCollection<MyCommandWrapper> MyButtons
        {
            get { return _commandWrapperCollection; }
            set
            {
                _commandWrapperCollection = value;
                OnPropertyChanged();
            }
        }
