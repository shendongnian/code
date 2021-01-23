    // One of the examples.
    CalculationEngine engine = new CalculationEngine();
    Func<Dictionary<string, double>, double> formula = engine.Build("var1+2/(3*otherVariable)");
    
    Dictionary<string, double> variables = new Dictionary<string, double>();
    variables.Add("var1", 2);
    variables.Add("otherVariable", 4.2);
    
    double result = formula(variables);
