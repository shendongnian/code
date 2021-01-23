    var src = new Bitmap("D:\\Untitled.png");
    var dst = new Bitmap(800, 700);
    
    using (var gr = Graphics.FromImage(dst))
    {
      gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
      gr.DrawImage(src, new Rectangle(0, 0, 800, 700));
    }
    
    dst.Dump();
