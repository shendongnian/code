	namespace StackOwerflow.Sample.Helpers
	{
		public static class UIElementExtensions
		{
			public static T FindControl<T>( this UIElement parent, string ControlName ) where T : FrameworkElement
			{
				if( parent == null )
					return null;
				if( parent.GetType() == typeof(T) && (( T )parent).Name == ControlName )
				{
					return ( T )parent;
				}
				T result = null;
				int count = VisualTreeHelper.GetChildrenCount( parent );
				for( int i = 0; i < count; i++ )
				{
					UIElement child = ( UIElement )VisualTreeHelper.GetChild( parent, i );
					if( FindControl<T>( child, ControlName ) != null )
					{
						result = FindControl<T>( child, ControlName );
						break;
					}
				}
				return result;
			}
		}
	}
