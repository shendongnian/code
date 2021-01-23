    Bitmap rBitmap = new Bitmap(600, 500);
    using (Graphics g = Graphics.FromImage(rBitmap)) {
      using (var br = new LinearGradientBrush(new Rectangle(0, 0, 600, 500),
             Color.DeepSkyBlue, Color.Green, LinearGradientMode.Vertical)) {
        br.SetSigmaBellShape(0.0f, 1f);
        g.FillRectangle(br, new Rectangle(0, 0, 600, 500));
      }
    }
    this.BackgroundImage = rBitmap;
