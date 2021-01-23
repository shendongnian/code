    private override OnPaint(object sender, PaintEventArgs e)
    {
        e.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
        e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
        e.Graphics.SmoothingMode = SmoothingMode.None;
        e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
        e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
        e.Graphics.CompositingMode = CompositingMode.SourceCopy;
        base OnPaint(sender, e)
    }
    
