    public static class GraphicsExtentions
    {
        public static void DrawEllipse(this Graphics g, Pen pen, double x, double y, double width, double height)
        {
            g.DrawEllipse(pen, (int)x, (int)y, (int)width, (int)height);
        }
    }
