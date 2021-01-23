    private void lblHeader_MouseDown(object sender, MouseEventArgs e)
    {
       isDragging = true;  // _dragging is your variable flag
       startPoint = Cursor.Position;
    }
    private void lblHeader_MouseUp(object sender, MouseEventArgs e)
    {
       isDragging = false;
    }
    private void lblHeader_MouseMove(object sender, MouseEventArgs e)
    {
        if (isDragging)
        {
            Point p = Cursor.Position;
            int deltaX = p.X - startPoint.X;
            int deltaY = p.Y - startPoint.Y;
            startPoint = p;
            this.Left += deltaX;
            this.Top += deltaY;
        }
     }
