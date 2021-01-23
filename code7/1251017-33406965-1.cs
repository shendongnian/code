    using NCalc;
    // ...
    string Tempreture = "20 > 13 && 20 < 18";
    NCalc.Expression e = new Expression(Tempreture);
    if ((bool)e.Evaluate())
    {
        //...
    }
    else
    {
        //...
    }
