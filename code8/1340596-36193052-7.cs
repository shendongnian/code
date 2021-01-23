    [Editor(typeof(MyDockEditor), typeof(UITypeEditor))]
    public override DockStyle Dock
    {
        get { return base.Dock; }
        set { base.Dock = value; }
    }
