		public static void Populate<T>( this Grid Parent, List<T> Children, Stretch ViewBoxStretch ) where T : UIElement {
			Parent.ColumnDefinitions.Clear( );
			Parent.RowDefinitions.Clear( );
			Parent.Children.Cast<Viewbox>( ).ToList( ).ForEach( VB => VB.Child = null );
			Parent.Children.Clear( );
			for ( int x = 0; x < Children.Count; x++ ) {
				Viewbox VB = new Viewbox( ) { Child = Children[x], Stretch = ViewBoxStretch };
				Parent.Children.Add( VB );
				Grid.SetColumn( VB, x % Math.Max( 3, ( int )( Math.Ceiling( Children.Count / 5.0D ) ) ) );
				Grid.SetRow( VB, x / Math.Max( 3, ( int )( Math.Ceiling( Children.Count / 5.0D ) ) ) );
			}
			int
				ColumnCount = Parent.Children.Cast<Viewbox>( ).Max( VB => Grid.GetColumn( VB ) ) + 1,
				RowCount = Parent.Children.Cast<Viewbox>( ).Max( VB => Grid.GetRow( VB ) ) + 1;
			for ( int x = 0; x < ColumnCount; x++ )
				Parent.ColumnDefinitions.Add( new ColumnDefinition( ) { Width = new GridLength( 1, GridUnitType.Star ) } );
			for ( int x = 0; x < RowCount; x++ )
				Parent.RowDefinitions.Add( new RowDefinition( ) { Height = new GridLength( 1, GridUnitType.Star ) } );
		}
