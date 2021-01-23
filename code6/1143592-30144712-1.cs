    private void ListView_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
	{
		if (!e.Handled)
		{
			e.Handled = true;
			var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
			eventArg.RoutedEvent = UIElement.MouseWheelEvent;
			eventArg.Source = sender;
			//navigate to the containing scrollbar and raise the MouseWheel event
			(((sender as ListView).Parent as GroupBox).Content as ListView).RaiseEvent(eventArg);
		}
	}
