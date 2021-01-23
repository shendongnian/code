	public class TouchDeviceMouseOverUIElementFixBehavior : Behavior<UIElement>
	{
		protected override void OnAttached()
		{
			AssociatedObject.StylusUp += AssociatedObject_StylusUp;
		}
		protected override void OnDetaching()
		{
			AssociatedObject.StylusUp -= AssociatedObject_StylusUp;
		}
		private void AssociatedObject_StylusUp(object sender, StylusEventArgs e)
		{
			var control = sender as FrameworkElement;
			if (control != null)
			{
				if (!VisualStateManager.GoToElementState(control, "Normal", true))
				{
					VisualStateManager.GoToState(control, "Normal", true);
				}
			}
		}
	}
