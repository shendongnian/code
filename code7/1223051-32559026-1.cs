    MethodInfo mi = GetTheMethodFromSomewhere();
    object[] args = new object[] { obj, param1, param2, … };
    if (mi.IsStatic)
        mi.Invoke(null, args);
    else
        mi.Invoke(args[0], args.Skip(1).ToArray());
