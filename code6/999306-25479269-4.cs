    private void DrawRectangle(Point pnt)
        {
            Graphics g = Graphics.FromImage(img);
            
            g.DrawImage(imgClone, 0, 0);
            if (pnt.X == RectStartPoint.X || pnt.Y == RectStartPoint.Y)
            {
                g.DrawLine(Pens.Firebrick, RectStartPoint.X, RectStartPoint.Y, pnt.X, pnt.Y);
            }
            else
            {
                g.DrawRectangle(Pens.Firebrick, Math.Min(RectStartPoint.X, pnt.X), Math.Min(RectStartPoint.Y, pnt.Y), 
                                Math.Abs(RectStartPoint.X - pnt.X), Math.Abs(RectStartPoint.Y - pnt.Y));
            }
            g.Dispose();
            
            pictureBoxSnap.Invalidate();
    }
