    public static System.Windows.Point ConvertToScreen(this System.Windows.Point point, CartesianExtents2D extents, double containerWidth, double containerHeight)
    {
        var x = (point.X - extents.XMinimum) * containerWidth / (extents.XMaximum - extents.XMinimum);
        var y = (extents.YMaximum - point.Y) * containerHeight / (extents.YMaximum - extents.YMinimum);
        return new System.Windows.Point(x, y);
   }
    public static System.Windows.Point ConvertToReal(this System.Windows.Point point, CartesianExtents2D extents, double containerWidth, double containerHeight, )
    {
        var x = extents.XMinimum + (point.X * (extents.XMaximum - extents.XMinimum)) / containerWidth;
        var y = extents.YMaximum - (point.Y * (extents.YMaximum - extents.YMinimum)) / containerHeight;
        return new System.Windows.Point(x, y);
    }
           
