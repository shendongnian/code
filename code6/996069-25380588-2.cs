    protected override void OnPaint(PaintEventArgs e)
    {
        // if you want smoother (anti-aliased) graphics, set these props
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        // draw all existing lines from the list
        using (var p = new Pen(Color.Black, 2f))
            foreach (var line in _lines)
                e.Graphics.DrawLine(p, line.Start, line.End);
            
        // if mouse is down, draw the dashed line also
        if (_currentLine != null)
            using (var p = new Pen(Color.Salmon, 2f))
            {
                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                e.Graphics.DrawLine(p, _currentLine.Start, _currentLine.End);
            }
        base.OnPaint(e);
    }
