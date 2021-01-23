    public ObservableCollection<ViewModelBase> FrameItems { get; protected set; }
    private ViewModelBase _selectedFrameItem;
    public ViewModelBase SelectedFrameItem {
        get { return _selectedFrameItem; }
        set {
            value = _selectedFrameItem;
            //  Defined in ViewModelBase
            OnPropertyChanged();
        }
    }
