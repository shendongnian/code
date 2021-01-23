    List<double> values = new List<double> { 100, 100, 200, 500, ... };
    values = values.Select(val => Hvariation(val)).ToList();
    // now all values have been altered by Hvariation
    ...
    private readonly Random _rand = new Random();
    public double Hvariation(double val) {
        return val + (val * (_rand.NextDouble(-0.5, 0.5)));
    }
