    using NCalc;
    // ...
    string Tempreture = "20 > 13 && 20 < 18";
    NCalc.Expression e = new Expression(Tempreture);
    if (e.HasErrors())
    {
        throw new ApplicationException("invalid expression");
    }
    if ((bool)e.Evaluate())
    {
        //...
    }
    else
    {
        //...
    }
