    public MyView()
	{
		InitializeComponent();
		MyViewModel viewModel = new MyViewModel();
		viewModel.AnimatedSnapToAction = zoomAndPanControl.AnimatedSnapTo;
		
		this.DataContext = viewModel;
	}
