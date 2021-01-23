    private void DrawShapes(Graphics g)
    {
        var p1= new Point(0,0);
        var topSize = new Size(450, 25);
        var bottomSize = new Size(450,350);
        var topRectangle= new Rectangle(p1.X, p1.Y, topSize.Width,  topSize.Height);
        var bottomRectangle= new Rectangle(p1.X, p1.Y + topSize.Height,  bottomSize.Width, bottomSize.Height);
        g.FillRectangle(Brushes.Blue, topRectangle);
        g.DrawRectangle(Pens.Lime, topRectangle);
        g.FillRectangle(Brushes.Red, bottomRectangle);
        g.DrawRectangle(Pens.Lime, bottomRectangle);
    }
