    static void Main(string[] args)
    {
        var area = ScaryMethod(new { rad = 3 }, t => t.rad);
    }
    public static double ScaryMethod<T>(T input, Func<T, double> radiusSelector)
    {
        var radius = radiusSelector(input);
        return Math.PI * Math.Pow(radius, 2);
    }
