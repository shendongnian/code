    private static readonly Pen _firedLine =
        new Pen(Color.Blue) { DashPattern = new [] { 5f, 2f } };
    private void LineDrawEvent(object sender, PaintEventArgs paint)
    {
        Graphics drawSurface = paint.Graphics;
        Pen turretLine = Pens.Blue;
        Pen graphHorizontal = Pens.Red;
        Pen graphVertical = Pens.Red;
        Pen targetLine = Pens.Black;
        drawSurface.DrawLine(graphVertical, (int)xOrigin, (int)yOrigin, (int)xHor, (int)yHor);
        drawSurface.DrawLine(graphHorizontal, (int)xOrigin, (int)yOrigin, (int)xVert, (int)yVert);
        drawSurface.DrawLine(_firedLine, (int)xOrigin, (int)yOrigin, (int)xFire, (int)yFire);
        drawSurface.DrawLine(targetLine, (int)xTarget, (int)yTarget, (int)xTarget, (int)yTargetEnd);
        double angleInRadians = ConvertDegsToRads((double)trckBarAngle.Value);
        xEnd = xOrigin + lineLength * Math.Cos(angleInRadians / 2.0);
        yEnd = yOrigin - lineLength * Math.Sin(angleInRadians / 2.0);
        drawSurface.DrawLine(turretLine, (int)xOrigin, (int)yOrigin, (int)xEnd, (int)yEnd);
    }
