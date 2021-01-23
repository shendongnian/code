    public SPList()
    {
        this.InitializeComponent();
        Task.Run(async () =>
        {
            IsLoading = true;
            ThreeColumnLists = await ThreeColumnListManager.GetList();
            IsLoading = false;
        }
    }
    
    private bool _isLoading;
    public bool IsLoading
    {
        get { return _isLoading; }
        set
        {
            if(_isLoading != value)
            {
                _isLoading = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsLoading));
            }
        }
    }
