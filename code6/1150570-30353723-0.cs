    public class Point
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public Point(
            [Range( -90,  90)]double x,
            [Range(-180, 180)]double y)
        {
            if (x > 90 || x < -90)
                throw new ArgumentOutOfRangeException("latitude");
            if (y > 180 || y < -180)
                throw new ArgumentOutOfRangeException("longitude");
            this.X = x;
            this.Y = y;
        }
    }
    [Fact]
    public void CreatePointDoesNotThrow()
    {
        var fixture = new Fixture();
        Assert.DoesNotThrow(() => fixture.Create<Point>()); // Passes.
    }
