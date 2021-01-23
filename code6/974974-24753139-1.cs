    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        if (!extended)
        {
            setColor();
            using (var backgroundBrush = new SolidBrush(currColor))
            {
                g.FillRectangle(backgroundBrush, this.ClientRectangle);
            }
        }
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        string szbuf = Program.AppName;
        g.FillRectangle(Brushes.White, 0, 0,
            this.ClientSize.Width, this.ClientSize.Height);
        StringFormat strformat = StringFormat.GenericDefault;
        SizeF sz = g.MeasureString(szbuf, this.Font);
        int w = ((this.Width / 2) - ((int)sz.Width / 2));
        int h = 10;
            
        using (var path = new GraphicsPath())
        {
            float emSize = g.DpiY * this.Font.Size / 72;
            path.AddString(szbuf, Font.FontFamily, 0, 48f, new Point(w, h), strformat);
            for (int i = 1; i < 8; ++i)
            {
                using (var pen = new Pen(getColor(), i))
                {
                    pen.LineJoin = LineJoin.Round;
                    g.DrawPath(pen, path);
                }
            }
            g.FillPath(Brushes.White, path);
        }
    }
