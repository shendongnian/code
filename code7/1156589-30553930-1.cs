    public static double DegreesToRadians(double degrees)
    {
        return degrees * (Math.PI / 180);
    }
    public static double RadiansToDegrees(double radians)
    {
        return radians * 180 / Math.PI;
    }
    double dLon = DegreesToRadians(LongDeg - lastLongDeg);
    double y = Math.Sin(dLon) * Math.Cos(DegreesToRadians(lastLatDeg));
    double x = Math.Cos(DegreesToRadians(lastLatDeg)) * Math.Sin(DegreesToRadians(LatDeg)) - Math.Sin(DegreesToRadians(lastLatDeg)) * Math.Cos(DegreesToRadians(LatDeg)) * Math.Cos(dLon);
    Console.WriteLine((RadiansToDegrees(Math.Atan2(y, x)) + 360.0) % 360);
    Console.WriteLine("> " + course + " <");
