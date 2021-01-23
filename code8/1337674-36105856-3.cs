    public static class GraphicsExtensions
    {
      public static void TranslateTransform(this Graphics g, float x, float y, float angle)
      {
        g.TranslateTransform(-x, -y);
        g.RotateTransform(angle);
        g.TranslateTransform(x, y);
      }
    }
