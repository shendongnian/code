	public static readonly DependencyProperty ProductProperty = DependencyProperty.Register(
	    "Product", typeof(ProductDto), typeof(ProductUserControl), new FrameworkPropertyMetadata(null));
	public ProductDto Product
	{
		get { return (ProductDto)this.GetValue(ProductProperty); }
		set { this.SetValue(ProductProperty, value); }
	}
	
	<TextBox Margin="2" Text="{Binding Path=Product.Code, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"/>
	<TextBox Margin="2" Text="{Binding Path=Product.Name, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"/>
	
