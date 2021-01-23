    bool btn = false;
    Point RectStartPoint = Point.Empty;
    Point RectEndPoint = Point.Empty;
    private void pictureBoxSnap_Paint(object sender, PaintEventArgs e)
    {
        if (pictureBoxSnap.Image != null)
        {
            {
                Rectangle Rect = getRect(RectStartPoint, RectEndPoint); ;
                if (Rect != Rectangle.Empty)
                {
                    e.Graphics.DrawRectangle(Pens.Firebrick, Rect);
                }
            }
        }
    }
    private void pictureBoxSnap_MouseMove(object sender, MouseEventArgs e)
    {
        if (btn == true)
        {
            RectEndPoint = e.Location;
            pictureBoxSnap.Invalidate();
        }
    }
    private void pictureBoxSnap_MouseDown(object sender, MouseEventArgs e)
    {
        RectStartPoint = e.Location;
        btn = true;
    }
    private void pictureBoxSnap_MouseUp(object sender, MouseEventArgs e)
    {
        btn = false;
        RectEndPoint = e.Location;
        pictureBoxSnap.Invalidate();
    }
    Rectangle getRect(Point p1, Point p2)
    {
        Point p = new Point(Math.Min(p1.X, p2.X),Math.Min(p1.Y, p2.Y) );
        Size s = new Size(Math.Abs(p1.X - p2.X), Math.Abs(p1.Y - p2.Y));
        return new Rectangle(p, s);
    }
