    public Func<double, double> ProductFunc(List<Func<double, double>> messages)
    {
        Func<double, double> productFunc = x => 1.0;
        foreach (Func<double, double> message in messages)
        {
            Func<double, double> currentFunc = productFunc;
            productFunc = x => currentFunc(x) * message(x);
        }
    
        return productFunc;
    }
