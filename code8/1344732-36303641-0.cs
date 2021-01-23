    var expr = new NCalc.Expression("CLng(1740263) * 1234");
    expr.EvaluateFunction += delegate(string name, NCalc.FunctionArgs args)
    {
        // Nostalgic CLng function...
        if (String.Equals(name, "CLng", StringComparison.CurrentCultureIgnoreCase))
        {
            args.HasResult = true;
            args.Result = Convert.ToInt64(args.EvaluateParameters()[0]);
        }
    };
