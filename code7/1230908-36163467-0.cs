    private void CustomControl_Load(object sender, EventArgs e)
    {        
        ParentChanged += OnParentChanged;
    }
    private void OnParentChanged(object sender, EventArgs e)
    {
        Parent.Resize += OnParentResize;
        Parent.LocationChanged += OnParentLocationChanged;
        // More events or
        // Do Something...
    }
