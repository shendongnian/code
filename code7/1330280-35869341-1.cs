    public static class GraphicsExtension
    {
        public static void DrawImage(this Graphics graphics, Image[] images, Point[] points)
        {
            for (int i = 0; i < images.Length; i++)
            {
                graphics.DrawImage(images[i], points[i]);
            }
        }
    }
