      MouseDevice mouseDevice = Mouse.PrimaryDevice;
      MouseButtonEventArgs mouseButtonEventArgs = new MouseButtonEventArgs(mouseDevice, 0, MouseButton.Left); 
      mouseButtonEventArgs.RoutedEvent = Mouse.MouseDownEvent;
      mouseButtonEventArgs.Source = this;
      RaiseEvent(mouseButtonEventArgs);
