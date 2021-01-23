    int X = 0; // Your parameter I guess?
    OperationExpression C1 = new OperationExpression(new ValueExpression(X),
        new ValueExpression(10), OperationExpression.Operations.MA);
    
    OperationExpression C2 = new OperationExpression(new ValueExpression(X),
        new ValueExpression(20), OperationExpression.Operations.MA);
    OperationExpression C3 = new OperationExpression(C1,
        new ValueExpression(5), OperationExpression.Operations.MA);
    OperationExpression C4 = new OperationExpression(C2,
        new ValueExpression(10), OperationExpression.Operations.MA);
    OperationExpression C5 = new OperationExpression(C3,
        new ValueExpression(15), OperationExpression.Operations.MA);
    OperationExpression C6 = new OperationExpression(C4
        new ValueExpression(10), OperationExpression.Operations.MA);
    OperationExpression Final = new OperationExpression(C6,
        C5, OperationExpression.Operations.Minus);
    var C1Result = C1.Solve();
    var C2Result = C2.Solve();
    var C3Result = C3.Solve();
    // etc
