    public bool Contains(Rectangle ellipse, Point location)
    {
        var contains = false;
        using(var gp= new System.Drawing.Drawing2D.GraphicsPath())
        {
            gp.AddEllipse(ellipse);
            contains = gp.IsVisible(location);
        }
        return contains;
    }
