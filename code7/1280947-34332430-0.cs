		public static Window GetParentWindow( DependencyObject obj )
		{
			return (Window)obj.GetValue( ParentWindowProperty );
		}
		public static void SetParentWindow( DependencyObject obj, Window value )
		{
			obj.SetValue( ParentWindowProperty, value );
		}
		public static readonly DependencyProperty ParentWindowProperty =
			DependencyProperty.RegisterAttached( "ParentWindow", typeof( Window ), typeof( AttachedProperties ), new PropertyMetadata( null ) );
	}`
