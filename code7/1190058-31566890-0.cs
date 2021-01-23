    var newMouseEvent = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left) 
    { 
    	RoutedEvent = Control.MouseDoubleClickEvent
    };
    myTextBox.RaiseEvent(newMouseEvent);
