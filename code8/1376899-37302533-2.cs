    private bool ButtonPreview = true;
    private void Button_TouchDown(object sender, TouchEventArgs e)
    {
        // task 1
        ButtonPreview = false;
    }
    private void Button_TouchUp(object sender, TouchEventArgs e)
    {
        // task 2
        // ..
    }
    private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (ButtonXPreview)
        {
            // task 1
        }
        else
            ButtonXPreview = true;
    
    }
    private void Button_PreviewMouseUp(object sender, MouseButtonEventArgs e)
    {
        if (ButtonXPreview)
        {
            // task 2
        }
        else
            ButtonXPreview = true;
    }
