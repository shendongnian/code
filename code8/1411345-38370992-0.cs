    private void lblHeader_MouseDown(object sender, MouseEventArgs e)
    {
       isDragging = true;  // _dragging is your variable flag
       startPoint = new Point(e.X, e.Y);
    }
    private void lblHeader_MouseUp(object sender, MouseEventArgs e)
    {
       isDragging = false;
    }
    private void lblHeader_MouseMove(object sender, MouseEventArgs e)
    {
        if (isDragging)
        {
            int deltaX = e.X - startPoint.X;
            int deltaY = e.Y - startPoint.Y;
            startPoint = new Point(e.X, e.Y);
            this.Left += deltaX;
            this.Top += deltaY;
        }
     }
