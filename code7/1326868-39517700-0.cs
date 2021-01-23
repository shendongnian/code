    <TextBox x:Name="myTextBox" PreventKeyboardDisplayOnProgrammaticFocus="True"/>
    public MainPage()
    {
        this.InitializeComponent();
	    timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromMilliseconds(500);
        timer.Tick += delegate
        {
            try
            {
                myTextBox.Focus(FocusState.Programmatic);
                timer.Stop();
            }
            catch { }
        };
    }
