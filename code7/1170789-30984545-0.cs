    public static string GetIDFromPropertyName<T>(Expression<Func<T>> exp)
    {
        var members = new List<string>();
        GetIDFromPropertyName(exp.Body, members);
        // members contains {"D", "C", "B", "a"}
            
        // now simply return the appropiate result, example:
        members.RemoveAt(members.Count -1);
        members.Reverse();
        return members.Aggregate((s1, s2) => s1 + "_" + s2);
    }
    private static void GetIDFromPropertyName(Expression exp, List<string> members)
    {
        var expression = exp as MemberExpression;
        if(expression != null)
        {
            var memberExpression = expression;
            members.Add(memberExpression.Member.Name);
            GetIDFromPropertyName(memberExpression.Expression, members);
        }
    }
