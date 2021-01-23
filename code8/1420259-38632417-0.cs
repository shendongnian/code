     private void ExtendedDraw(PaintEventArgs e)
    {
        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
        e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
        e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, Color.White, Color.White, 90); //here you need your target rectangle
        GraphicsPath path = new GraphicsPath();
        path.StartFigure();
        path.StartFigure();
        path.AddArc(GetLeftUpper(Edge), 180, 90);
        path.AddLine(Edge, 0, Width - Edge, 0);
        path.AddArc(GetRightUpper(Edge), 270, 90);
        path.AddLine(Width, Edge, Width, Height - Edge);
        path.AddArc(GetRightLower(Edge), 0, 90);
        path.AddLine(Width - Edge, Height, Edge, Height);
        path.AddArc(GetLeftLower(Edge), 90, 90);
        path.AddLine(0, Height - Edge, 0, Edge);
        path.CloseFigure();
        e.Graphics.FillPath(brush, path);
    }
