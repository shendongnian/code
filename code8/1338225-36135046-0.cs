    var g = e.Graphics;
    var loc = new Point(128, 128);
    var rect = new Rectangle(0, 0, 64, 16);
    
    g.ResetTransform();
    g.TranslateTransform(loc.X, loc.Y);
    g.FillRectangle(Brushes.Blue, rect);
    
    g.ResetTransform();
    g.TranslateTransform(loc.X, loc.Y);
    g.RotateTransform(90);
    g.FillRectangle(Brushes.Red, rect);
    
    g.ResetTransform();
    g.TranslateTransform(loc.X, loc.Y);
    g.RotateTransform(180);
    g.FillRectangle(Brushes.Green, rect);
    
    g.ResetTransform();
    g.TranslateTransform(loc.X, loc.Y);
    g.RotateTransform(270);
    g.FillRectangle(Brushes.Magenta, rect);
