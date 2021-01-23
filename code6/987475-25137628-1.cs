    String script = MyProject.Resources.Script; 
    string[] scriptSplit = script.Split(new string[]{"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
    SymbolicExpression rscriptSplitSymbolicExpression = rEngine.CreateCharacterVector(scriptSplit);
    rEngine.SetSymbol("rscriptSplitSymbolicExpression", rscriptSplitSymbolicExpression);
    rEngine.Evaluate("eval(parse(text=rscriptSplitSymbolicExpression))");
