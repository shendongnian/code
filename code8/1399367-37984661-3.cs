       Bitmap bmp = new Bitmap(200, 200);
    
       using (Graphics g = Graphics.FromImage(bmp)) {
         FillPoly(g, Color.Blue, Color.Red,
           new Point(5, 5),
           new Point(105, 6),
           new Point(85, 95),
           new Point(125, 148),
           new Point(8, 150));
       }
