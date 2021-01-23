    ViewModel vm;
    
    public View()
    {
    	InitializeComponent();
    	vm = new ViewModel();
    	DataContext = vm;
    }
