	private ProductDto product;
	public ProductDto Product
	{
		get { return this.product; }
		set { this.SetValue(ref this.product, value); } // Set value raises the PropertyChanged event
	}
	
