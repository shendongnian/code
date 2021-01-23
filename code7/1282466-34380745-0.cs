    public CustomPopupControl()
    {
                this.InitializeComponent();
    
                Window.Current.CoreWindow.CharacterReceived += CoreWindow_CharacterReceived;
    }
    
    private void CoreWindow_CharacterReceived(CoreWindow sender, CharacterReceivedEventArgs args)
    {
                if(args.KeyCode==27) //ESC
                {
    		//Do somthing
                    this.Visibility = Visibility.Collapsed;
                }
    }
