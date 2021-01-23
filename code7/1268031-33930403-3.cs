    public DBDisplay() 
    {
    	InitializeComponent();
    	
    	var viewModel = new DBDisplayViewModel();
    	viewModel.UserRepository = new UserRepository(); // You could use dependency injection but I left for simplicity.
    	this.DataContext = viewModel;
    }
