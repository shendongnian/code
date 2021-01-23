    static Direction GetDirection(Point p1, Point p2)
    {
        double rad = Math.Atan2(p2.Y - p1.Y, p2.X - p1.X);
        // Ajust result to be between 0 to 2*Pi
        if (rad < 0)
            rad = rad + (2 * Math.PI);
        int deg = (int)(rad * (180 / Math.PI));
        switch (deg)
        {
            case 0:
                return Direction.East;
            case 45:
                return Direction.Northeast;
            case 90:
                return Direction.North;
            case 135:
                return Direction.Northwest;
            case 180:
                return Direction.West;
            case 225:
                return Direction.Southwest;
            case 270:
                return Direction.South;
            case 315:
                return Direction.Southeast;
            default:
                return Direction.Undefined;
        }
    }
