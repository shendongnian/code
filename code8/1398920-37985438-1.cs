    private void OnConnection(object obj)
    {
        var text = GetTextFromClickOnGrid(obj);
    }
    
    private string GetTextFromClickOnGrid(object obj)
    {
        var grid = obj as Grid;
        if (grid != null)
        {
            var mousePos = Mouse.GetPosition(grid);
            var itemUnderMouse = VisualTreeHelper.HitTest(grid, mousePos);
            var textBlock = itemUnderMouse.VisualHit as TextBlock;
            if (textBlock != null)
            {
                return textBlock.Text;
            }
        }
    
        var textBlockUnderMouse = Mouse.DirectlyOver as TextBlock;
        if (textBlockUnderMouse != null)
        {
            return textBlockUnderMouse.Text;
        }
    
        return string.Empty;
    }
