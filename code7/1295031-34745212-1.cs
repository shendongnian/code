    static void Main(string[] args)
    {
        var seq = CreatePolynomialSequence(1, 2, 3);
        Console.WriteLine(seq.Invoke(1)); // yields 6 = 1 + 2 + 3
        Console.WriteLine(seq.Invoke(2)); // yields 11 = 1*4 + 2*2 + 3
    }
    public static Func<int, double> CreatePolynomialSequence(params double[] coeff)
    {
        Expression<Func<int, double>> e = x => 0;
        double pow = 0;
        for (int i = coeff.Length - 1; i >= 0; i--)
        {
            var p = e.Parameters[0];
            double c = coeff[i];
            var _pow = pow; // avoid closing over the outer variable
            var next = (Expression<Func<int, double>>)(x => c * Math.Pow(x, _pow));
            var nextInvoked = Expression.Invoke(next, p);
            e = Expression.Lambda<Func<int, double>>(Expression.Add(e.Body, nextInvoked), p);
            pow++;
        }
        return e.Compile();
    }
