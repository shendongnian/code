    public Settings()
        {
            this.InitializeComponent();
            Windows.Phone.UI.Input.HardwareButtons.BackPressed +=
            HardwareButtons_BackPressed;       
        }
        void HardwareButtons_BackPressed(object sender,
            Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            if (this.Frame != null && this.Frame.CanGoBack)
            {
                e.Handled = true;
                this.Frame.GoBack();
            }
        }
