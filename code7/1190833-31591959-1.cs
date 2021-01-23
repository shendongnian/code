    SecondPageViewModel spvm;
    public SecondPage(SecondPageViewModel model)
    {
        spvm = model;
        this.DataContext = spvm;
        InitializeComponent();
    }
