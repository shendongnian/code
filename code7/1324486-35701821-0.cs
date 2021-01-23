	public static readonly DependencyProperty
		ColorProperty = DependencyProperty.Register( "Color", typeof( Color ), typeof( ColorModel ),
			new PropertyMetadata(
				Colors.Black,
				async ( S, E ) => await ( S as ColorModel ).OnPropertyChanged( "Color" ).DontBlock( ) ) ),
		AlphaProperty = DependencyProperty.Register( "Alpha", typeof( double ), typeof( ColorModel ),
			new PropertyMetadata(
				1.0D,
				async ( S, E ) => await ( S as ColorModel ).OnPropertyChanged( "Alpha" ).DontBlock( ) ) );
