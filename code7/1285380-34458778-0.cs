    public enum DisplayMode { Vertical, Horizontal, Diagonal }
    private DisplayMode currentMode;
    public DisplayMode CurrentMode
    {
        get { return currentMode; }
        set { SetProperty(ref currentMode, value); }
    }
