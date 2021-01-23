    MethodInfo mi = GetTheMethodFromSomewhere();
    object[] params = new object[] { obj, param1, param2, … };
    if (mi.IsStatic)
        mi.Invoke(null, params);
    else
        mi.Invoke(params[0], params.Skip(1).ToArray());
