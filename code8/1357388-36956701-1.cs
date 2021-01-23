    Action emptyDelegate = delegate { };
    bool IsContentRendered = false;
    private void WindowViewBase_Loaded(object sender, RoutedEventArgs e)
	{
			SetInterfaceElements();
			Dispatcher.Invoke(emptyDelegate, DispatcherPriority.Render);<---to refresh
			IsContentRendered = true;
	}
