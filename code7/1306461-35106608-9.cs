    public static Direction GetDirection(Point p1, Point p2) {
        double angle = Math.Atan2(p2.Y - p1.Y, p2.X - p1.X);
        angle += Math.PI;
        angle /= Math.PI / 4;
        int halfQuarter = Convert.ToInt32(angle);
        halfQuarter %= 8;
        return (Direction)halfQuarter;
    }
