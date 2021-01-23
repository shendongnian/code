    void drawInto(Control ctl)
    {
        Bitmap bmp = new Bitmap(ctl.ClientSize.Width, ctl.ClientSize.Height);
        using ( Graphics G = Graphics.FromImage(bmp))
        {
            // all your drawing code goes here..!
            G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            G.DrawEllipse(Pens.DimGray, ctl.ClientRectangle);
            // ..
            // ..
        }
        ctl.BackgroundImage = bmp;
    }
