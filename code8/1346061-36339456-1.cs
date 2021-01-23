    using (var graphics = Graphics.FromImage(GraphicsImage))
    {
      graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
      graphics.DrawImage(iconImg, 5, 5);
    }
