    public static class IsDraggingBehaviour
	{
		public static bool GetSelectAll(YourControl target)
		{
			return (bool)target.GetValue(IsDraggingAttachedProperty);
		}
		public static void SetSelectAll(YourControl target, bool value)
		{
			target.SetValue(IsDraggingAttachedProperty, value);
		}
		public static readonly DependencyProperty IsDraggingAttachedProperty = DependencyProperty.RegisterAttached("IsDragging", typeof(bool), typeof(YourControl), new UIPropertyMetadata(false, OnSelectIsDraggingPropertyChanged));
		static void OnSelectIsDraggingPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			var control = (YourControl) o;
			//control.AccessYourProperty = true; change your value here
		}
	}
