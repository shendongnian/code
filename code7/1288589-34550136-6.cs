    public static void MakeNonVirtualCall<T>(T c, Expression<Action<T>> f)
    {
        var expression = f.Body as MethodCallExpression;
        if (expression == null) throw new ArgumentException();
        
        var dyn = new DynamicMethod("NVCall", null, new[] { typeof(T) }, typeof(T).Module, true);
        var il = dyn.GetILGenerator();
        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Call, expression.Method);
        il.Emit(OpCodes.Ret);
        ((Action<T>)dyn.CreateDelegate(typeof(Action<T>)))(c);
    }
