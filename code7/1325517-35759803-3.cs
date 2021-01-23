	public static class ButtonHelper
	{
		public static double GetCornerRadius(DependencyObject obj)
		{
			return (double)obj.GetValue(CornerRadiusProperty);
		}
		public static void SetCornerRadius(DependencyObject obj, double value)
		{
			obj.SetValue(CornerRadiusProperty, value);
		}
		// Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty CornerRadiusProperty =
			DependencyProperty.RegisterAttached("CornerRadius", typeof(double), typeof(ButtonHelper), new PropertyMetadata(0.0));
		public static string GetButtonText(DependencyObject obj)
		{
			return (string)obj.GetValue(ButtonTextProperty);
		}
		public static void SetButtonText(DependencyObject obj, string value)
		{
			obj.SetValue(ButtonTextProperty, value);
		}
		// Using a DependencyProperty as the backing store for ButtonText.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty ButtonTextProperty =
			DependencyProperty.RegisterAttached("ButtonText", typeof(string), typeof(ButtonHelper), new PropertyMetadata(""));
		
	}
