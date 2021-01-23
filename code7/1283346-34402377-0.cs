    private double Angle(Point origin, Point target)
    {
        // Get the vector from origin->point
        Vector vecTo = target - origin;
        // Normalize the vector
        vecTo.Normalize();
        // 0-angle is pointing straight up, aligned with (0, -1). 
        // The equation for the angle between 2 vectors is acos(Dot(v1, v1))
        // Our DotProduct is trivial, as know v1 is (0, -1).  This exands
        // 0 * v2.X + -1 * v2.Y
        double dotAngle = -vecTo.Y;
        double angle = Math.Acos(dotAngle);
        // Convert to rad
        angle = angle * 180 / Math.PI;
        // ACos will always return a positive number, but because Cos is
        // symmetric around 0 a -ve number is also valid,  Figure out which
        // is correct by taking the Dot vs (1, 0).  If result is positive,
        // then vecTo point in the same general direction as (1, 0), and
        // the angle returned should also be positive.  I've skipped
        // all the actual math, but thats the idea.
        if (vecTo.X > 0)
            return angle;
        else
            return -angle;
    }
