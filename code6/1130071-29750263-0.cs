    'Returns the X,Y coordinate of a point on a clock given a center point and radius.  
    'Clock point 0 = 12:00, 1 = 1:00, etc.
    Private Function getClockPoint(center As PointF, radius As Double, clockPoint As Integer) As PointF
        Dim angle As Double = clockPoint * (2.0 * Math.PI) / 12.0
        Dim x As Single = center.X + CSng(radius * Math.Sin(angle))
        Dim y As Single = center.Y + CSng(radius * Math.Cos(angle))
        Return New PointF(x, y)
    End Function
