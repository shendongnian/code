    pinPoint.LostMouseCapture += Point_LostMouseCapture;
    .
    .
    .
    void Point_LostMouseCapture(object sender, MouseEventArgs e)
    {
        //if we lost the capture but we are still dragging then just recapture it
        if (_isDragging)
        {
            ((UIElement)sender).CaptureMouse();
        }
    }
