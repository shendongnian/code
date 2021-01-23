    private List<Dictionary<JoinOptionsExpression,int>> selections = new List<Dictionary<JoinOptionsExpression,int>>{new Dictionary<JoinOptionsExpression,int>()};
    override VisitJoin(JoinExpression join)
    {
        var choices = new Expression[] { MergeJoinExpresion.Create(join), NestLoopJoinExpresion.Create(join) };
        List<Expression> exprs = new List<Expression>();
        foreach(var choice in choices)
        {
             var cloned = Cloner.Clone(choice);
             var newTree = base.VisitJoin(cloned);
             exprs.Add(newTree);
        }
        var result = JoinOptionsExpression.Create(exprs);
        // now add all choices
        if (exprs.Count > 0)
            foreach (selection in selections.ToList()) // to make sure your don't modify during enumeration, you can improve this too
            {
                selection.Add(result, 0);
                for (i=1; i<exprs.Count; i++)
                {
                    var copy= new Dictionary<JoinOptionsExpression, int>(selection);
                    copy[result] = i;
                    selections.Add(copy);
                }
            }
        return result;
    }
