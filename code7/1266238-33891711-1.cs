    public static readonly DependencyProperty ComplexObjectProperty =
			DependencyProperty.Register("ComplexObject", 
										typeof(ComplexObject), 
										typeof(CheckableComplexObjectGroup), 
										new PropertyMetadata(null));
	private static readonly DependencyProperty VisibleComplexObjectProperty =
			DependencyProperty.Register("VisibleComplexObject", 
										typeof(ComplexObject), 
										typeof(CheckableComplexObjectGroup), 
										new PropertyMetadata(new ComplexObject()));
    //...
    protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
	{
		if (e.Property == ComplexObjectProperty)
		{
			if (null != e.NewValue)
				VisibleComplexObject = ComplexObject;
		}
			
		base.OnPropertyChanged(e);
	}
	private void cbComplexObject_Checked(object sender, RoutedEventArgs e)
	{
		ComplexObject = VisibleComplexObject;
	}
	private void cbComplexObject_Unchecked(object sender, RoutedEventArgs e)
	{
		ComplexObject = null;
	}
