    public MainPage()
    {
        InitializeComponent();
        _callbacks = new Dictionary<object, PivotCallbacks>();
        _callbacks[pivotItem1] = new PivotCallbacks
        {
            Initiate = ShowAppbar,
            OnAvtivated = ShowAppbar
        };
        _callbacks[pivotItem2] = new PivotCallbacks
        {
            OnAvtivated = HideAppbar
        };
        _callbacks[pivotItem3] = new PivotCallbacks
        {
            OnAvtivated = HideAppbar
        };
        foreach (var callbacks in _callbacks.Values)
        {
            if (callbacks.Initiate != null)
            {
                callbacks.Initiate();
            }
        }
    }
