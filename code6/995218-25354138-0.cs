	public static class CalandarHelper 
	{
		public static readonly DependencyProperty SingleClickDefocusProperty =
			DependencyProperty.RegisterAttached("SingleClickDefocus", typeof(bool), typeof(Calendar)
			, new FrameworkPropertyMetadata(false, new PropertyChangedCallback(SingleClickDefocusChanged)));
		public static bool GetSingleClickDefocus(DependencyObject obj) {
			return (bool)obj.GetValue(SingleClickDefocusProperty);
		}
		public static void SetSingleClickDefocus(DependencyObject obj, bool value) {
			obj.SetValue(SingleClickDefocusProperty, value);
		}
		
		private static void SingleClickDefocusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is Calendar) 
			{
				Calendar calendar = d as Calendar;
				calendar.PreviewMouseDown += (a, b) =>
				{
					if (Mouse.Captured is Calendar || Mouse.Captured is System.Windows.Controls.Primitives.CalendarItem)
					{
						Mouse.Capture(null);
					}
				};
			}
		}
	}
