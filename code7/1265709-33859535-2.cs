    var transparency = 0;
    protected override OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      // e.Graphics.DrawImage(Image, imageLeft, imageTop, imageWidth, imageHeight);
      e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(transparency, Black)),   this.ClientRectangle);
    }
