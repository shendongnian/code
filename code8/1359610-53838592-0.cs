    public static IEnumerable<Point> GeneratePoints(double size, float percentage)
    {
        if (percentage < 0 || percentage > 1)
        {
            throw new ArgumentException();
        }
        var halfSize = size / 2;
        var origin = new Point(halfSize, halfSize);
        var topMiddle = new Point(halfSize, 0);
        var topRight = new Point(size, 0);
        var bottomRight = new Point(size, size);
        var bottomLeft = new Point(0, size);
        var topLeft = new Point(0, 0);
        if (percentage == 1)
        {
            return new[] { topLeft, topRight, bottomRight, bottomLeft };
        }
        var degrees = percentage * 360;
        var adjustedDegrees = (degrees + 90) % 360;
        if (adjustedDegrees >= 90 && adjustedDegrees < 135)
        {
            var angleDegrees = adjustedDegrees - 90;
            var angleRadians = ToRadians(angleDegrees);
            var tan = Math.Tan(angleRadians);
            var oppositeEdge = tan * halfSize;
            return new[] { origin, topMiddle, new Point(halfSize + oppositeEdge, 0) };
        }
        if (adjustedDegrees >= 135 && adjustedDegrees < 180)
        {
            var angleDegrees = adjustedDegrees - 135;
            var angleRadians = ToRadians(angleDegrees);
            var tan = Math.Tan(angleRadians);
            var oppositeEdge = tan * halfSize;
            return new[] { origin, topMiddle, topRight, new Point(size, oppositeEdge) };
        }
        if (adjustedDegrees >= 180 && adjustedDegrees < 225)
        {
            var angleDegrees = adjustedDegrees - 180;
            var angleRadians = ToRadians(angleDegrees);
            var tan = Math.Tan(angleRadians);
            var oppositeEdge = tan * halfSize;
            return new[] { origin, topMiddle, topRight, new Point(size, halfSize + oppositeEdge) };
        }
        if (adjustedDegrees >= 225 && adjustedDegrees < 270)
        {
            var angleDegrees = adjustedDegrees - 225;
            var angleRadians = ToRadians(angleDegrees);
            var tan = Math.Tan(angleRadians);
            var oppositeEdge = tan * halfSize;
            return new[] { origin, topMiddle, topRight, bottomRight, new Point(size - oppositeEdge, size) };
        }
        if (adjustedDegrees >= 270 && adjustedDegrees < 315)
        {
            var angleDegrees = adjustedDegrees - 270;
            var angleRadians = ToRadians(angleDegrees);
            var tan = Math.Tan(angleRadians);
            var oppositeEdge = tan * halfSize;
            return new[] { origin, topMiddle, topRight, bottomRight, new Point(halfSize - oppositeEdge, size) };
        }
        if (adjustedDegrees >= 315 && adjustedDegrees < 360)
        {
            var angleDegrees = adjustedDegrees - 315;
            var angleRadians = ToRadians(angleDegrees);
            var tan = Math.Tan(angleRadians);
            var oppositeEdge = tan * halfSize;
            return new[] { origin, topMiddle, topRight, bottomRight, bottomLeft, new Point(0, size - oppositeEdge) };
        }
        if (adjustedDegrees >= 0 && adjustedDegrees < 45)
        {
            var angleDegrees = adjustedDegrees;
            var angleRadians = ToRadians(angleDegrees);
            var tan = Math.Tan(angleRadians);
            var oppositeEdge = tan * halfSize;
            return new[] { origin, topMiddle, topRight, bottomRight, bottomLeft, new Point(0, halfSize - oppositeEdge) };
        }
        if (adjustedDegrees >= 45 && adjustedDegrees < 90)
        {
            var angleDegrees = adjustedDegrees - 45;
            var angleRadians = ToRadians(angleDegrees);
            var tan = Math.Tan(angleRadians);
            var oppositeEdge = tan * halfSize;
            return new[] { origin, topMiddle, topRight, bottomRight, bottomLeft, topLeft, new Point(oppositeEdge, 0) };
        }
        return new Point[0];
    }
    public static double ToRadians(float val)
    {
        return (Math.PI / 180) * val;
    }
