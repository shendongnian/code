    public static int FindMinMax(int x, int y, string method)
    {
        MethodInfo mi = typeof(Math).GetMethod(method, new[] { typeof(int), typeof(int) });
        return (int)mi.Invoke(null, new object[] { x, y} );
    }
