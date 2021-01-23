    private void TextBoxPreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Subtract)
        {
            e.Handled = true;
    
            var text = "-";
            var target = Keyboard.FocusedElement;
            var routedEvent = TextCompositionManager.TextInputEvent;
    
            target.RaiseEvent(
                new TextCompositionEventArgs
                    (
                         InputManager.Current.PrimaryKeyboardDevice,
                        new TextComposition(InputManager.Current, target, text)
                    )
                    {
                        RoutedEvent = routedEvent
                    });
        }
    }
