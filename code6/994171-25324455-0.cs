    private void DragSourcePreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        isMouseDown = true;
    }
    private void DragSourcePreviewMouseMove(object sender, MouseEventArgs e)
    {
        if (isMouseDown && IsConfirmedDrag(e.GetPosition(sender as ListBox)))
        {
            isMouseDown = false;
            ...
            DragDrop.DoDragDrop(dragSource, data, DragDropEffects);
        }
    }
