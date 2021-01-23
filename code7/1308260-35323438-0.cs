    public XGraphicsPath GetSurroundPath(XGraphicsPath path, double width)
    {
        XGraphicsPath container = new XGraphicsPath();
        container.StartFigure();
        container.AddPath(path, false);
        container.CloseFigure();
        var penOffset = new XPen(XColors.Black, width);
        container.StartFigure();
        container.Widen(penOffset);
        container.CloseFigure();
        var iterator = new GraphicsPathIterator(container.Internals.GdiPath);
        bool isClosed;
        var outline = new XGraphicsPath();
        iterator.NextSubpath(outline.Internals.GdiPath, out isClosed);
        return outline;
    }
