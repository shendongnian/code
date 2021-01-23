    GraphicsPath p = new GraphicsPath();
    p.AddString(MarkerSymbol, markerFont.FontFamily, (int)markerFont.Style, symbolSize.Height * 0.9f, CorrectedSymbolLocation, stringFormat);
    var iter = new GraphicsPathIterator(p);
    while (true)
    {
        var subPath = new GraphicsPath();
        bool isClosed;
        if (iter.NextSubpath(subPath, out isClosed) == 0) break;
        Region region = new Region(subPath);
        graphics.FillRegion(new SolidBrush(Color.White), region);
    }
    graphics.FillPath(brush, p);
