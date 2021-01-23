    foreignControl.RaiseEvent(new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left)
    {
      RoutedEvent = Mouse.MouseUpEvent,
      Source = this,
    });
