	public Window_NewProduct(ProductDto product)
	{
		InitializeComponent();
		this.DataContext = new Window_NewProductViewModel() { Product = product ?? new ProductDto() };
	}
		
	public ProductDto Product
	{
		get
		{
			var viewModel = this.DataContext as DetailsWindowViewModel;
			return viewModel.Product;
		}
	}
	
