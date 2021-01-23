       Bitmap bmp = new Bitmap(200, 200);
    
       using (Graphics g = Graphics.FromImage(bmp)) {
         FillPoly(g, Color.Blue, Color.Red,
          new Point(105, 5),
          new Point(5, 120),
          new Point(190, 108));
       }
