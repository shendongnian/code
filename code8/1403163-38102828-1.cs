    public void MyCheck(Expression expr)
    {
        BoolExpr boolVal = dispatch(expr);
        Console.WriteLine(boolVal);
        MySolver.Assert(boolVal); // use property
        Console.WriteLine("\n ");
        Console.WriteLine(MySolver.Check());
        Console.WriteLine(ReturnTrueFalse(s));
        Console.WriteLine("\n ");
    }
