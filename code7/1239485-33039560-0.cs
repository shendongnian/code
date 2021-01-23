    private static void DrawLinesOnBitmap(Bitmap bmp)
    {
       using (var p = new Pen(Color.Black, 5))
       {
          using (var g = Graphics.FromImage(bmp))
          {
             g.DrawLine(p, 0, 0, bmp.Width, bmp.Height);
          }
       }
    }
