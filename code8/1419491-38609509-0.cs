    private MainViewModel Context
    {
        get
        {
            return DataContext as MainViewModel;
        }
    }
    public GenerateView()
    {
        InitializeComponent();
		DataContextChanged += GenerateView_DataContextChanged;
    }
	private void GenerateView_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
	{
		if (Context != null)
			Context.PropertyChanged += Context_PropertyChanged;
	}
    private void Context_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        //Action to perform
    }
