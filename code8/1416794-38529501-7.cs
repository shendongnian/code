    private static Dictionary<Type, Dictionary<string, Action<object, object>>> _typeMapper = new Dictionary<Type, Dictionary<string, Action<object, object>>>();
    public static void Set(object obj, string fieldName, object newValue)
    {
        if (obj == null)
        {
            throw new ArgumentNullException("obj");
        }
        Type type = obj.GetType();
        Dictionary<string, Action<object, object>> fieldMapper;
        Action<object, object> action;
        if (_typeMapper.TryGetValue(type, out fieldMapper))
        {
            // entry has been created for this type.
            if (!fieldMapper.TryGetValue(fieldName, out action))
            {
                // method has not been created yet, must build it.
                FieldInfo fld = type.GetField(fieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (fld == null)
                {
                    throw new ArgumentException("No field " + fieldName);
                }
                action = buildSetter(fld);
                fieldMapper.Add(fieldName, action); // add it to method cache for future use.
            }
        }
        else
        {
            // -- ADDED CODE: forgot to create the new fieldMapper.....
            fieldMapper = new Dictionary<string, Action<object, object>>();
         // type has not been added yet, so we know method has not been built yet either.
            FieldInfo fld = type.GetField(fieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (fld == null)
            {
                throw new ArgumentException("No field " + fieldName);
            }
            action = buildSetter(fld);
            fieldMapper.Add(fieldName, action); // add it to method cache for future use.
            _typeMapper.Add(type, fieldMapper); // add it to type cache for future use.
        }
        action(obj, newValue); // invoke the method.
    }
    // this is my preferred setter-builder, feel free to use expressions instead.
    private static Action<object, object> buildSetter(FieldInfo fld)
    {
        DynamicMethod dyn = new DynamicMethod("set_" + fld, typeof(void), new[] { typeof(object), typeof(object) }, fld.DeclaringType);
        ILGenerator gen = dyn.GetILGenerator();
        gen.Emit(OpCodes.Ldarg_0);
        gen.Emit(OpCodes.Castclass, fld.DeclaringType);
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
        return (Action<object, object>)dyn.CreateDelegate(typeof(Action<object, object>));
    }
