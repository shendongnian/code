    public bool HitTest(PictureBox control, int x, int y)
    {
        var result = false;
        if (control.Image == null)
            return result;
        var method = typeof(PictureBox).GetMethod("ImageRectangleFromSizeMode",
          System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var r = (Rectangle)method.Invoke(control, new object[] { control.SizeMode });
        using (var bm = new Bitmap(r.Width, r.Height))
        {
            using (var g = Graphics.FromImage(bm))
                g.DrawImage(control.Image, 0, 0, r.Width, r.Height);
            if (r.Contains(x, y) && bm.GetPixel(x - r.X, y - r.Y).A != 0)
                result = true;
        }
        return result;
    }
