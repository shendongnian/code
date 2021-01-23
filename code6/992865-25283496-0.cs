    private void PreviewDragOver(object sender, DragEventArgs e)
    {
        HitTestResult hitTestResult = VisualTreeHelper.HitTest(adornedUIElement, 
            e.GetPosition(adornedUIElement));
        Control controlUnderMouse = hitTestResult.VisualHit.GetParentOfType<Control>();
    }
