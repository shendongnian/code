    /// <summary>
    /// Round polygon corners
    /// </summary>
    /// <param name="points">Vertices array</param>
    /// <param name="radius">Round radius</param>
    /// <returns></returns>
    static public GraphicsPath RoundCorners(PointF[] points, float radius) {
        GraphicsPath retval = new GraphicsPath();
        if (points.Length < 3) {
            throw new ArgumentException();
        }
        rects = new RectangleF[points.Length];
        PointF pt1, pt2;
        //Vectors for polygon sides and normal vectors
        Vector v1, v2, n1 = new Vector(), n2 = new Vector();
        //Rectangle that bounds arc
        SizeF size = new SizeF(2 * radius, 2 * radius);
        //Arc center
        PointF center = new PointF();
        for (int i = 0; i < points.Length; i++) {
            pt1 = points[i];//First vertex
            pt2 = points[i == points.Length - 1 ? 0 : i + 1];//Second vertex
            v1 = new Vector(pt2.X, pt2.Y) - new Vector(pt1.X, pt1.Y);//One vector
            pt2 = points[i == 0 ? points.Length - 1 : i - 1];//Third vertex
            v2 = new Vector(pt2.X, pt2.Y) - new Vector(pt1.X, pt1.Y);//Second vector
            //Angle between vectors
            float sweepangle = (float)Vector.AngleBetween(v1, v2);
            //Direction for normal vectors
            if (sweepangle < 0) { 
                n1 = new Vector(v1.Y, -v1.X);
                n2 = new Vector(-v2.Y, v2.X);
            }
            else {
                n1 = new Vector(-v1.Y, v1.X);
                n2 = new Vector(v2.Y, -v2.X);
            }
            n1.Normalize(); n2.Normalize();
            n1 *= radius; n2 *= radius;
            /// Points for lines which intersect in the arc center
            PointF pt = points[i];
            pt1 = new PointF((float)(pt.X + n1.X), (float)(pt.Y + n1.Y));
            pt2 = new PointF((float)(pt.X + n2.X), (float)(pt.Y + n2.Y));
            double m1 = v1.Y / v1.X, m2 = v2.Y / v2.X;
            //Arc center
            if (v1.X == 0) {// first line is parallel OY
                center.X = pt1.X;
                center.Y = (float)(m2 * (pt1.X - pt2.X) + pt2.Y);
            }
            else if (v1.Y == 0) {// first line is parallel OX
                center.X = (float)((pt1.Y - pt2.Y) / m2 + pt2.X);
                center.Y = pt1.Y;
            }
            else if (v2.X == 0) {// second line is parallel OY
                center.X = pt2.X;
                center.Y = (float)(m1 * (pt2.X - pt1.X) + pt1.Y);
            }
            else if (v2.Y == 0) {//second line is parallel OX
                center.X = (float)((pt2.Y - pt1.Y) / m1 + pt1.X);
                center.Y = pt2.Y;
            }
            else {
                center.X = (float)((pt2.Y - pt1.Y + m1 * pt1.X - m2 * pt2.X) / (m1 - m2));
                center.Y = (float)(pt1.Y + m1 * (center.X - pt1.X));
            }
            rects[i] = new RectangleF(center.X - 2, center.Y - 2, 4, 4);
            //Tangent points on polygon sides
            n1.Negate(); n2.Negate();
            pt1 = new PointF((float)(center.X + n1.X), (float)(center.Y + n1.Y));
            pt2 = new PointF((float)(center.X + n2.X), (float)(center.Y + n2.Y));
            //Rectangle that bounds tangent arc
            RectangleF rect = new RectangleF(new PointF(center.X - radius, center.Y - radius), size);
            sweepangle = (float)Vector.AngleBetween(n2, n1);
            retval.AddArc(rect, (float)Vector.AngleBetween(new Vector(1, 0), n2), sweepangle);
        }
        retval.CloseAllFigures();
        return retval;
    }
