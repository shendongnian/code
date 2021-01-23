    InputManager.Current.PreProcessInput += (sender, e) =>
    {
        if (e.StagingItem.Input is MouseButtonEventArgs)
        {
            var earg = (MouseButtonEventArgs)e.StagingItem.Input;
            if (earg.RoutedEvent == Mouse.PreviewMouseDownOutsideCapturedElementEvent)
                OnPreviewMouseDownOutsideCapturedElement(sender, earg);
        }
    };
