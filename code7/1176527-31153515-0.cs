    await Task.WhenAll(dtable4.AsEnumerable().Select(row4 => new Task(() =>
    {
        string getCondition = row4[1].ToString();
        getCondition = EvaluateCondExpression(getCondition);  //Evaluates CM for value (CM1==2 && CM2<5);
        Expression e = new Expression(getCondition); //getCondition = (2==2 && 2<5)
        var evalutateCondition = e.Evaluate();
        if (Convert.ToBoolean(evalutateCondition))
        {
            //Write string to TextBox
        }
    })));
