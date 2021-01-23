    Popup popUP = new Popup();
    public MainPage()
    {
       InitializeComponent();
       this.SizeChanged += MainPage_SizeChanged;
     }
    double systemTrayHeight =30;
    double popUPHeight = 200;
    private void MainPage_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        if (popUP.IsOpen)
             popUP.IsOpen = false;
         popUP.Child = new PopUP();
         popUP.VerticalOffset = e.NewSize.Height + systemTrayHeight - popUPHeight;
         popUP.IsOpen = true;
    }
