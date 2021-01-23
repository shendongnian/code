    public List<PointF> getCorners(RectangleF r)
    {
        return new List<PointF>() { r.Location, new PointF(r.Right, r.Top),
            new PointF(r.Right, r.Bottom), new PointF(r.Left, r.Bottom)};
    }
