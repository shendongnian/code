    public MainPage()
    {
        this.InitializeComponent();
        MyControl.CloseSplitViewPane += (sender, e) =>
        {
             SplitView.IsPaneOpen = false;
        };
    }
