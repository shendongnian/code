        using System.Drawing.Imaging;
        ..
        ..
        Rectangle abc = new Rectangle(-783, -383, bmpSS.Width, bmpSS.Height);
        GraphicsPath gp = new GraphicsPath();
        // three points to make up a triangle
        // repeat the first one as one way of closing the path
        // use your own coordinates!
        Point[] p = new Point[] { new Point(12, 34), new Point(56, 78), 
                                  new Point(90, 12), new Point(12, 34) };
        gp.AddLines(p);       // or AddPolygon
        gfxSS.SetClip(gp);    // now restrict the Graphics object to the interior of the path
        gfxSS.DrawImage(bmpSS, abc, -783, -383, bmpSS.Width, bmpSS.Height,
                         GraphicsUnit.Pixel, attributes);
