    public class Point
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public Point(double x, double y)
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
        var x = new Generator<int>(fixture).First(pt => pt >  -90 && pt <  90);
        var y = new Generator<int>(fixture).First(pt => pt > -180 && pt < 180);
        fixture.Customize<Point>(c => c
            .FromFactory(() => new Point(x, y)));
        Assert.DoesNotThrow(() => fixture.Create<Point>()); // Passes.
    }
