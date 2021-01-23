    private void moveUserControl (MouseEventArgs e)
    {
        Point mousePos = e.GetPosition(LayoutRoot);
        Double newX = LocalTranslateTransform.X + (mousePos.X - DragOffset.X);
        Double newY = LocalTranslateTransform.Y + (mousePos.Y - DragOffset.Y);
        var minX = 0;
        var maxX = 500 - ActualWidth; // 500 is parent width
        var minY = 0;
        var maxY = 500 - ActualHeight; // 500 is parent height
        if (newX < minX)
        {
            newX = minX;
        }
        else if (newX > maxX)
        {
            newX = maxX;
        } 
        if (newY < minY)
        {
            newY = minY;
        }
        else if (newY > maxY)
        {
            newY = maxY;
        } 
        LocalTranslateTransform.X = newX;
        LocalTranslateTransform.Y = newY;
    }
