    private void DragSourcePreviewMouseMove(object sender, MouseEventArgs e)
    {
        ListBox dragSourceControl = (ListBox)sender;
        HitTestResult result = VisualTreeHelper.HitTest(dragSourceControl, 
            Mouse.GetPosition(dragSourceControl));
        UIElement draggedUIElement = result.VisualHit.GetParentOfType<ListBoxItem>();
        bool isViable = AddYourViabilityConditionHere(draggedUIElement);
        if (isMouseDown && IsConfirmedDrag(e.GetPosition(sender as ListBox)) && isViable)
        {
            isMouseDown = false;
            ...
            DragDrop.DoDragDrop(dragSource, data, DragDropEffects);
        }
    }
