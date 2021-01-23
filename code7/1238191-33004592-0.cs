        public MainPage()
        {
            this.InitializeComponent();
            bool isHardwareButtonsAPIPresent =
                Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons");
            if(isHardwareButtonsAPIPresent)
            {
                // add Windows Mobile extenstions for UWP
                Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
            }
        }
        private void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            // hareware button pressed
        }
