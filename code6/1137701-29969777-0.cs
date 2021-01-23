    static void Main(string[] args)
    {
        var result = Mul();
    }
    public static double Add()
    {
        return EvaluateConst() + EvaluateConst();
    }
    public static double Mul()
    {
        return EvaluateConst() * Add();
    }
    public static double EvaluateConst()
    {
        return 2;
    }
