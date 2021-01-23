      // Following code derives a cutout bitmap using a
      // scizzor path as a clipping region (like Paint would do)
      // Result bitmap has a minimal suitable size, pixels outside 
      // the clipping path will be white.
      public static Bitmap ApplyScizzors(Bitmap bmpSource, List<PointF> pScizzor)
        {
            GraphicsPath graphicsPath = new GraphicsPath();   // specified Graphicspath          
            graphicsPath.AddPolygon(pScizzor.ToArray());      // add the Polygon
            var rectCutout = graphicsPath.GetBounds();        // find rectangular range           
            Matrix m = new Matrix();
            m.Translate(-rectCutout.Left, -rectCutout.Top);   // translate clip to (0,0)
            graphicsPath.Transform(m);
            Bitmap bmpCutout = new Bitmap((int)(rectCutout.Width), (int)(rectCutout.Height));  // target
            Graphics graphicsCutout = Graphics.FromImage(bmpCutout);
            graphicsCutout.Clip = new Region(graphicsPath);
            graphicsCutout.DrawImage(bmpSource, (int)(-rectCutout.Left), (int)(-rectCutout.Top)); // draw
            graphicsPath.Dispose();
            graphicsCutout.Dispose();
            return bmpCutout;
        }
