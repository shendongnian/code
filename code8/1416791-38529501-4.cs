    private static Dictionary<string, Action<MyType, object>> _mapper = new Dictionary<string, Action<MyType, object>>();
    public static void Set(MyType obj, string fieldName, object newValue)
    {
        if (obj == null)
        {
            throw new ArgumentNullException("obj");
        }
        Action<MyType, object> action;
        if (!_mapper.TryGetValue(fieldName, out action))
        {
            action = buildSetter(typeof(MyType).GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));
            _mapper.Add(fieldName, action);
        }
        action(obj, newValue); // invoke the method.
    }
    private static Action<MyType, object> buildSetter(FieldInfo fld)
    {
        DynamicMethod dyn = new DynamicMethod("set_" + fld, typeof(void), new[] { typeof(MyType), typeof(object) }, typeof(MyType));
        ILGenerator gen = dyn.GetILGenerator();
        gen.Emit(OpCodes.Ldarg_0);
        gen.Emit(OpCodes.Ldarg_1);
        if (fld.FieldType.IsClass)
        {
            gen.Emit(OpCodes.Castclass, fld.FieldType);
        }
        else
        {
            gen.Emit(OpCodes.Unbox_Any, fld.FieldType);
        }
        gen.Emit(OpCodes.Stfld, fld);
        gen.Emit(OpCodes.Ret);
        return (Action<MyType, object>)dyn.CreateDelegate(typeof(Action<MyType, object>));
    }
