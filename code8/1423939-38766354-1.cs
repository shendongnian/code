    private void inkCanvas_PointerPressed(object sender, PointerRoutedEventArgs e)
    {
        // Accept input only from a pen or mouse with the left button pressed.
        PointerDeviceType pointerDevType = e.Pointer.PointerDeviceType;
        if (pointerDevType == PointerDeviceType.Pen)
        {
            //TODO:
        }
        else
        {
            // Process touch or mouse input
            inkCanvas.Visibility = Visibility.Collapsed;
        }
    }
    
    private void scrollViewer_PointerPressed(object sender, PointerRoutedEventArgs e)
    {
        PointerDeviceType pointerDevType = e.Pointer.PointerDeviceType;
        if (pointerDevType == PointerDeviceType.Pen)
        {
            inkCanvas.Visibility = Visibility.Visible;
        }
        else
        {
            // Process touch or mouse input
            inkCanvas.Visibility = Visibility.Collapsed;
        }
    }
 
