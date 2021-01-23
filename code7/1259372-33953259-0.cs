    public ClickBehavior(FrameworkElement _fe)
        : base(_fe)
    {
        fe.IsManipulationEnabled = true;
        fe.MouseLeftButtonDown += OnMouseLeftButtonDown;
        fe.TouchDown           += OnTouchDown;
    }
