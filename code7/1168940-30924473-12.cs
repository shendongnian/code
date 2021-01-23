    static void saveLargeForm(Form form, string fileName)
    {
        // yes it may take a while
        form.Cursor = Cursors.WaitCursor;
        // allocate target bitmap and a buffer bitmap
        Bitmap target = new Bitmap(form.DisplayRectangle.Width, form.DisplayRectangle.Height);
        Bitmap buffer = new Bitmap(form.Width, form.Height);
        // the vertical pointer
        int y = 0;
        var vsc = form.VerticalScroll;
        vsc.Value = 0;
        form.AutoScrollPosition = new Point(0, 0);
        // the scroll amount
        int l = vsc.LargeChange;
        Rectangle srcRect = ClientBounds(form);
        Rectangle destRect = Rectangle.Empty;
        bool done = false;
        // we'll draw onto the large bitmap with G
        using (Graphics G = Graphics.FromImage(target))
        {
            while (!done)
            {
                destRect = new Rectangle(0, y, srcRect.Width, srcRect.Height);
                form.DrawToBitmap(buffer, new Rectangle(0, 0, form.Width, form.Height));
                G.DrawImage(buffer, destRect, srcRect, GraphicsUnit.Pixel);   
                int v = vsc.Value;
                vsc.Value = vsc.Value + l;
                form.AutoScrollPosition = new Point(form.AutoScrollPosition.X, vsc.Value + l);
                int delta = vsc.Value - v;
                done = delta < l;
                y += delta;
            }
            destRect = new Rectangle(0, y, srcRect.Width, srcRect.Height);
            form.DrawToBitmap(buffer, new Rectangle(0, 0, form.Width, form.Height));
            G.DrawImage(buffer, destRect, srcRect, GraphicsUnit.Pixel);
        }
        // write result to disc and clean up
        target.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
        target.Dispose();   
        buffer.Dispose();      
        GC.Collect();          // not sure why, but it helped
        form.Cursor = Cursors.Default;    
    }
