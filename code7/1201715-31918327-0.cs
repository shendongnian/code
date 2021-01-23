    string source = "a";
    string ValToCheck = "A";
    StringComparison StrComp = StringComparison.CurrentCultureIgnoreCase;
    MethodInfo miContain = typeof(StringExts).GetMethod("NewContains", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
    var bEXP = Expression.Call(miContain, Expression.Constant(source), Expression.Constant(ValToCheck), Expression.Constant(StrComp));
    // Get the result
    var lambda = Expression.Lambda<Func<bool>>(bEXP);
    bool b = lambda.Compile().Invoke();
