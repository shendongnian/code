        //Creating graphics path for drawing bezier spline
        GraphicsPath gp = new GraphicsPath();
        gp.AddLine(new Point(100, 0), new Point(100, 100));
        gp.AddBezier(startPoint, ctPoint1, ctPoint2, endPoint);
        gp.AddLine(new Point(200, 100), new Point(200, 0));
        gp.AddLine(new Point(100, 0), new Point(200, 0));
        //Dividing the path into two regions
        Rectangle bounds=Rectangle.Round(gp.GetBounds());
        Region left = new Region(gp);
        left.Exclude(new Rectangle(bounds.Left, bounds.Top, (int)(bounds.Width / 2), bounds.Height));
        
        Region right = new Region(gp);
        right.Exclude(new Rectangle((int)(bounds.Left + bounds.Width / 2), bounds.Top, (int)(bounds.Width / 2), bounds.Height));
        //Drawing divided regions
        e.Graphics.FillRegion(Brushes.Black, left);
        e.Graphics.FillRegion(Brushes.Aqua, right);
