    var expression =
        Expression.Call(
            typeof (HostStatus).GetMethod("GetHostStatus", BindingFlags.Public | BindingFlags.Static),
            Expression.Call(
                typeof (HostNumber).GetMethod("GetHostNumber", BindingFlags.Public | BindingFlags.Static),
                Expression.Constant("Bleacher", typeof (string))));
    var func = Expression.Lambda<Func<string>>(expression).Compile();
    var result = func();
