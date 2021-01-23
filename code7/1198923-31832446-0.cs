    public App()
    {
        this.InitializeComponent();
        this.Suspending += this.OnSuspending;
    
        HardwareButtons.BackPressed += HardwareButtons_BackPressed;
    }
    
    void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
    {
        Frame rootFrame = Window.Current.Content as Frame;
    
        if (rootFrame != null && rootFrame.CanGoBack)
        {
            e.Handled = true;
            rootFrame.GoBack();
        }
    }
