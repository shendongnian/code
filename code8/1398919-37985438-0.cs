    public DelegateCommand<Object> MouseCommand { get; set; }
    public WindowViewModel(IEventAggregator eventAggregator)
    {
        MouseCommand = new DelegateCommand<object>(OnConnection);
    }
