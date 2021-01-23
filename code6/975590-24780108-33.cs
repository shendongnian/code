    //One point for each degree. But in some cases it will be necessary 
    // to use more points. Just change a degreeFactor.
    int pointsCount = (int)Math.Abs(sweepAngle * degreeFactor);
    int sign = Math.Sign(sweepAngle);
    PointF[] points = new PointF[pointsCount];
    for (int i = 0; i < pointsCount; ++i)
    {
        var pointX = 
           (float)(circlePoint.X  
                   + Math.Cos(startAngle + sign * (double)i / degreeFactor)  
                   * radius);
        var pointY = 
           (float)(circlePoint.Y 
                   + Math.Sin(startAngle + sign * (double)i / degreeFactor) 
                   * radius);
        points[i] = new PointF(pointX, pointY);
    }
