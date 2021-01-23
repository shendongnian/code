    Dictionary<string, double> variables = new Dictionary<string, double>();
    variables.Add("var1", 2.5);
    variables.Add("var2", 3.4);
    
    CalculationEngine engine = new CalculationEngine();
    double result = engine.Calculate("var1*var2", variables);
