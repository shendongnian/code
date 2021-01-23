    private void CanvasLayout_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        if (draggedImage != null)
        {
            CanvasLayout.ReleaseMouseCapture();
            Panel.SetZIndex(draggedImage, 0);
            BindingOperations.ClearBinding(draggedImage, ContentControl.OpacityProperty);
            draggedImage = null;
        }
    }
