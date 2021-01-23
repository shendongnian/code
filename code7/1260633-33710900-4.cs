    public MainPage()
    {
        this.InitializeComponent();
    }
    private void bCustomPopup_Click(object sender, RoutedEventArgs e)
    {
        popupMask.Width = Window.Current.Bounds.Width;
        popupMask.Height = Window.Current.Bounds.Height;
        Window.Current.SizeChanged += Current_SizeChanged;
        PopupOne.IsOpen = true;
    }
    private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
    {
        popupMask.Width = Window.Current.Bounds.Width;
        popupMask.Height = Window.Current.Bounds.Height;
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        PopupOne.IsOpen = false;
        Window.Current.SizeChanged -= Current_SizeChanged;
    }
