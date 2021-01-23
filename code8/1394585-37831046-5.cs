    Bitmap orig = new Bitmap(@"path");
    Bitmap clone = new Bitmap(orig.Width, orig.Height,
        System.Drawing.Imaging.PixelFormat.Format24bppRgb);
    
    using (Graphics gr = Graphics.FromImage(clone)) {
        gr.DrawImage(orig, new Rectangle(0, 0, clone.Width, clone.Height));
    }
    
