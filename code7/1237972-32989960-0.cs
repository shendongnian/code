    // Source page
    frame.Navigate(new MyPage(myParameter));
    
    // Target page
    public MyPage()
    {
        InitializeComponent();
    }
    
    public MyPage(TypeOfParameter myParameter) : this()
    {
       // use myParameter here
    }
