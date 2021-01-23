    ParameterExpression source = Expression.Parameter(typeof(string));
    string ValToCheck = "A";
    StringComparison StrComp = StringComparison.CurrentCultureIgnoreCase;
    MethodInfo miContain = typeof(StringExts).GetMethod("NewContains", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
    var bEXP = Expression.Call(miContain, source, Expression.Constant(ValToCheck), Expression.Constant(StrComp));
    var lambda = Expression.Lambda<Func<string, bool>>(bEXP, source);
    bool b = lambda.Compile().Invoke("a");
