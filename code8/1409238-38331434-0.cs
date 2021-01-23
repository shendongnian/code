    // Create the calculation engine
    CalculationEngine engine = new CalculationEngine();
    ExpressionContext context = new ExpressionContext();
    VariableCollection variables = context.Variables;
    
    // Add some variables
    variables.Add("x", 100);            
    variables.Add("y", 200);
    
    // Add an expression to the calculation engine as "a"
    engine.Add("a", "x * 2", context);
    
    // Add an expression to the engine as "b"
    engine.Add("b", "y + 100", context);
                
    // Add an expression at "c" that uses the results of "a" and "b"
    engine.Add("c", "a + b", context);
                
    // Get the value of "c"
    int result = engine.GetResult<int>("c");
    
    // Update a variable on the "a" expression            
    variables["x"] = 200;
    
    // Recalculate it
    engine.Recalculate("a");
    
    // Get the updated result
    result = engine.GetResult<int>("c");
