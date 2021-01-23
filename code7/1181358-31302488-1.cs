      public static readonly DependencyProperty SelectedGelPakProperty =
        DependencyProperty.Register(
            "SelectedGelPak",
            typeof(object),
            typeof(GelPakPickerOverlay),
            new FrameworkPropertyMetadata(
                null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    public static readonly DependencyProperty LocationProperty =
        DependencyProperty.Register(
            "Location",
            typeof(string),
            typeof(GelPakPickerOverlay),
            new FrameworkPropertyMetadata(string.Empty, OnLocationChanged));
    public static readonly DependencyProperty GelPakSourceProperty =
        DependencyProperty.Register(
            "GelPakSource",
            typeof(IEnumerable),
            typeof(GelPakPickerOverlay),
            new FrameworkPropertyMetadata(null, OnGelPakSourceChanged));
    public static readonly DependencyProperty SaveCommandProperty =
        DependencyProperty.Register(
            "SaveCommand",
            typeof(ICommand),
            typeof(GelPakPickerOverlay),
            new FrameworkPropertyMetadata(null, OnSaveCommandChanged));
    public GelPakPickerOverlay()
    {
        this.MainPanel.DataContext = this;
    }
    public object SelectedGelPak
    {
        get { return GetValue(SelectedGelPakProperty); }
        set { SetValue(SelectedGelPakProperty, value); }
    }
    public string Location
    {
        get { return GetValue(LocationProperty).ToString(); }
        set { SetValue(LocationProperty, value); }
    }
    public IEnumerable GelPakSource
    {
        get { return (IEnumerable) GetValue(GelPakSourceProperty); }
        set { SetValue(GelPakSourceProperty, value); }
    }
    public ICommand SaveCommand
    {
        get { return (ICommand) GetValue(SaveCommandProperty); }
        set { SetValue(SaveCommandProperty, value); }
    }
    }
