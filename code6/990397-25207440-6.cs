    public MyView()
	{
		InitializeComponent();
		MyViewModel viewModel = new MyViewModel();
		viewModel.AnimatedToSnapAction = zoomAndPanControl.AnimatedSnapTo;
		
		this.DataContext = viewModel;
	}
