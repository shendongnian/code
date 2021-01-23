    static void Main(string[] args)
    {
        var response = Add();
        var result = response();
    }
    public static Func<double> Add()
    {
        return () => Mul()() + EvaluateConst()();
    }
    public static Func<double> Mul()
    {
        return () => EvaluateConst()() * EvaluateConst()();
    }
