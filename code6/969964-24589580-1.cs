    private void maindg_GotFocus(object sender, RoutedEventArgs e)
    {
        if (!maindg.CanUserAddRows)
        {
            maindg.CanUserAddRows = true;
        }
    }
    
    private void maindg_LostFocus(object sender, RoutedEventArgs e)
    {
        if (!maindg.IsKeyboardFocusWithin && maindg.CanUserAddRows)
        {
            maindg.CanUserAddRows = false;
        }
    }
