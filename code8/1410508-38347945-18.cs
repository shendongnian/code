    var result = false;
    using (var path = new GraphicsPath())
    {
        path.AddEllipse(p.X, p.Y, d, d);
        result = path.IsVisible(e.Location);
    }
