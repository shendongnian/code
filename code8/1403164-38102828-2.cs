    public bool isContradiction(Expression expr)
    {
        BoolExpr boolVal = dispatch(expr);
        MySolver.Assert(boolVal);
        Status result = MySolver.Check();
        return result == Status.UNSATISFIABLE;
    }
