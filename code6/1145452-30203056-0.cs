    private void MyRectangle_DragOver(object sender, DragEventArgs e)
    {
        Point p = e.GetPosition(MyRectangle);
        if ((p.X > 0) && (p.X < MyRectangle.ActualWidth) && (p.Y > 0) && (p.Y < (MyRectangle.ActualHeight / 2)))
        {
            Mouse.OverrideCursor = Cursors.UpArrow;
        }
        else
        {
            Mouse.OverrideCursor = null;
        }
    }
