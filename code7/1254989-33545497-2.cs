    public static class ObjectExtensionTryCast
    {
        public static bool TryCast<T>(this object o, out T castedValue)
        {
            MethodInfo castMethod = new string[] { "op_Implicit", "op_Explicit" }
                .Select(methodName => o.GetType()
                    .GetMethod(methodName, BindingFlags.Static | BindingFlags.Public, null, new[] { o.GetType() }, null))
                .Where(method => method.ReturnType == typeof(T))
                .FirstOrDefault();
            bool canCast = castMethod != null;
            castedValue = canCast ?
                (T)castMethod.Invoke(null, new object[] { o }) :
                default(T);
            return canCast;
        }
    }
