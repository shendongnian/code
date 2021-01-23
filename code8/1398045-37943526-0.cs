    private void AddHotKeys()
    {
            try
            {
                RoutedCommand firstSettings = new RoutedCommand();
                firstSettings.InputGestures.Add(new KeyGesture(Key.A, ModifierKeys.Alt));
                CommandBindings.Add(new CommandBinding(firstSettings , My_first_event_handler));
 
                RoutedCommand secondSettings = new RoutedCommand();
                secondSettings.InputGestures.Add(new KeyGesture(Key.B, ModifierKeys.Alt));
                CommandBindings.Add(new CommandBinding(secondSettings , My_second_event_handler));
            }
            catch (Exception err)
            {
                //handle exception error
            }
    }
