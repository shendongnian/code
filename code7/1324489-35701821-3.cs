	public ColorModel( ) {
		MultiBinding MB = new MultiBinding( );
		MB.Converter = new ColorMultiConverter( );
		MB.Bindings.Add( new Binding( "Alpha" ) { Source = this, Mode = BindingMode.TwoWay } );
		MB.Bindings.Add( new Binding( "Red" ) { Source = this, Mode = BindingMode.TwoWay } );
		MB.Bindings.Add( new Binding( "Green" ) { Source = this, Mode = BindingMode.TwoWay } );
		MB.Bindings.Add( new Binding( "Blue" ) { Source = this, Mode = BindingMode.TwoWay } );
		BindingOperations.SetBinding( this, ColorProperty, MB );
	}
