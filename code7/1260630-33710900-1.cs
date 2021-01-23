    public MainPage()
    {
        this.InitializeComponent();
    }
    private void bCustomPopup_Click(object sender, RoutedEventArgs e)
    {
        popupMask.Width = Window.Current.Bounds.Width;
        popupMask.Height = Window.Current.Bounds.Height;
        PopupOne.IsOpen = true;
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        PopupOne.IsOpen = false;
    }
