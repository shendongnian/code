    private bool ButtonPreview = true;
    private void Button_TouchDown(object sender, TouchEventArgs e)
    {
        // task
        // ..
        ButtonPreview = false;
    }
    private void Button_TouchUp(object sender, TouchEventArgs e)
    {
        // some task
        // ..
    }
    private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (ButtonXPreview)
        {
            // task
            // ..
        }
        else
            ButtonXPreview = true;
    
    }
    private void Button_PreviewMouseUp(object sender, MouseButtonEventArgs e)
    {
        if (ButtonXPreview)
        {
            // task
            // ..
        }
        else
            ButtonXPreview = true;
    }
