    public void drawUpdates(List<areaObjects> objectLocations)
    {
        Rectangle areaToClone = new Rectangle(0, 0, writeOnceMap.Width, writeOnceMap.Height);
        var pixelFormat = writeOnceMap.PixelFormat;
        areaBitMap = writeOnceMap.Clone(areaToClone, pixelFormat);
        using(Pen drawPen = new Pen(Color.Black, 2))
        {
        drawPen.Width = 2;
        foreach(areaObjectsop2d in objectLocations)
        {
            int xPosition = (int)(op2d.XYZ.xPos * mapScale);
            int yPosition = (int)(op2d.XYZ.yPos * mapScale);
            Point[] crossMarker = getCrossShape(xPosition, yPosition);
    
            using (var graphics = Graphics.FromImage(areaBitMap))
            {
                graphics.DrawPolygon(drawPen, crossMarker);
            }
        }
        }
    }
