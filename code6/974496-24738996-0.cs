    double[] doubleList = { 2, 3, 4 };
                
    string methodName = "Min";
    var t = typeof(Enumerable);
    MethodInfo method = t.GetMethods(BindingFlags.Static | BindingFlags.Public)
                     .Where(m => m.Name == methodName && m.ReturnType == typeof(double))
                     .FirstOrDefault();
    object val = method.Invoke(t, new object[]{ doubleList });
