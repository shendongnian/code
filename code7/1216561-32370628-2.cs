    public static bool IsAlternating(double[] data)
    {
        var d = GetDerivative(data);
        var signs = d.Select(val => Math.Sign(val));
        bool isAlternating =
       signs.Zip(signs.Skip(1), (a, b) => a != b).All(isAlt => isAlt);
    
        return isAlternating;
    }
    private static IEnumerable<double> GetDerivative(double[] data)
    {
        var d = data.Zip(data.Skip(1), (a, b) => b - a);
        return d;
    }
