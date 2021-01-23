    public static List<Expression<Func<Person, bool>>> GetExpressions()
    {
        var expressionList = new List<Expression<Func<Person, bool>>>();
        expressionList.Add(x => x.Id > 0);
        expressionList.Add(x => x.Age > 18);
        return expressionList;
    }
