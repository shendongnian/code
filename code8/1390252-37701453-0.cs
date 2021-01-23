    <KeyBinding Key="Add" Command="{Binding ZoomInCommand}"></KeyBinding>
    public ICommand ZoomInCommand
    {
        get
        {
            _zoomIn = new DelegateCommand(CallZoomIn());
            return zoomIn;
        }
    }
