    // Draws an ellipse using 2 beziers.
    private void DrawEllipse(Graphics g, PointF center, float width, float height, double rotation)
    {
      // Unrotated ellipse frame
      float left   = center.X - width / 2;
      float right  = center.X + width / 2;
      float top      = center.Y - height / 2;
      float bottom   = center.Y + height / 2;
      PointF p1 = new PointF(left, center.Y);
      PointF p2 = new PointF(left, top);
      PointF p3 = new PointF(right, top);
      PointF p4 = new PointF(right, center.Y);
      PointF p5 = new PointF(right, bottom);
      PointF p6 = new PointF(left, bottom);
      
      // Draw ellipse with rotated points.
      g.DrawBezier(Pens.Black, Rotate(p1, center, rotation), Rotate(p2, center, rotation), Rotate(p3, center, rotation), Rotate(p4, center, rotation));
      g.DrawBezier(Pens.Black, Rotate(p4, center, rotation), Rotate(p5, center, rotation), Rotate(p6, center, rotation), Rotate(p1, center, rotation));
    }
    // Rotating a given point by given angel around a given pivot.
    private PointF Rotate(PointF point, PointF pivot, double angle)
    {
      float x = point.X - pivot.X;
      float y = point.Y - pivot.Y;
      double a = Math.Atan(y / x);
      if (x < 0)
      {
        a += Math.PI;
      }
      float size = (float)Math.Sqrt(x * x + y * y);
      double newAngel = a + angle;
      float newX = ((float)Math.Cos(newAngel) * size);
      float newY = ((float)Math.Sin(newAngel) * size);
      return pivot + new SizeF(newX, newY);
    }
