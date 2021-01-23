    private bool _enabled;
    public bool Enabled
    {
        get
        {
            return _enabled;
        }
        set
        {
            if (_enabled != value)
            {
                _enabled = value;
                RaisePropertyChanged("Enabled");
                if (EnabledChanged != null)
                {
                    EnabledChanged(this, EventArgs.Empty);
                }
            }
        }
    }
    public event EventHandler EnabledChanged;
<!-- / -->
    // constructor
    public ViewModel()
    {
        this.EnabledChanged += This_EnabledChanged;
    }
    
    private This_EnabledChanged(object sender, EventArgs e)
    {
        // do stuff here
    }
