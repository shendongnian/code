	public class GridViewColumnVisibilityManager
	{
		static Dictionary<GridViewColumn, double> originalColumnWidths = new Dictionary<GridViewColumn, double>();
		static Dictionary<GridViewColumn, Style> originalColumnHeader = new Dictionary<GridViewColumn, Style>();
		public static bool GetIsVisible(DependencyObject obj)
		{
			return (bool)obj.GetValue(IsVisibleProperty);
		}
		public static void SetIsVisible(DependencyObject obj, bool value)
		{
			obj.SetValue(IsVisibleProperty, value);
		}
		public static readonly DependencyProperty IsVisibleProperty =
				DependencyProperty.RegisterAttached("IsVisible", typeof(bool), typeof(GridViewColumnVisibilityManager), new UIPropertyMetadata(true, OnIsVisibleChanged));
		private static void OnIsVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			GridViewColumn gc = d as GridViewColumn;
			if (gc == null)
				return;
			if (GetIsVisible(gc) == false)
			{
				originalColumnWidths[gc] = gc.Width;
				gc.Width = 0;
				originalColumnHeader[gc] = gc.HeaderContainerStyle;
				gc.HeaderContainerStyle = Application.Current.FindResource("disabledColumn") as Style;
			}
			else
			{
				if (gc.Width == 0)
				{
					gc.Width = originalColumnWidths[gc];
					gc.HeaderContainerStyle = originalColumnHeader[gc];
				}
			}
		}
	}
