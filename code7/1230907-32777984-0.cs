    public YourControl()
    {
        InitializeComponent();
        ParentChanged += OnParentchanged;
    }
    private void OnParentchanged(object sender, EventArgs e)
    {
        // maybe get Form istead of just parent control
        Parent.Resize += OnParentResize;
        Parent.LocationChanged += OnParentLocationChanged;
    }
