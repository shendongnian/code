    MethodInfo method = typeof(RestHelper).GetMethod(
        "Get",                                           // method name
        BindingFlags.Static | BindingFlags.Public,       // binding flags
        null,
        new Type[] { typeof(long), typeof(string) },     // parameter types
        null);
    MethodInfo genericMethod = method.MakeGenericMethod(viewModel);
    genericMethod.Invoke(null, new object[] { 1, entity });
