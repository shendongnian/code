    public SplitViewPage()
    {
        this.InitializeComponent();
    
        this.splitView.RegisterPropertyChangedCallback(SplitView.IsPaneOpenProperty, IsPaneOpenPropertyChanged);
    }
    
    private void IsPaneOpenPropertyChanged(DependencyObject sender, DependencyProperty dp)
    {
        // put your logic here
    }
