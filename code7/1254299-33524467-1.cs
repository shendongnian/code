    public static int D(params object[] paramArray)
    {
        var paramTypes = paramArray.Select(x => x.GetType());
        var method = typeof(Static.A).GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy)
            .Where(m => m.Name == "B" && m.GetParameters().Select(x => x.ParameterType).SequenceEqual(paramTypes))
            .FirstOrDefault();
        if (method != null)
        {
            return (int)method.Invoke(null, paramArray);
        }
        throw new Exception("Overloaded method not found");
    }
