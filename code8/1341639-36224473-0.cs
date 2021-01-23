    public static Func<ValueType, ValueType, bool> GetValueTypeEquals()
    {
        var type = typeof(ValueType);
        var dynamicMethod = new DynamicMethod("ValueTypeEquals", typeof(bool), new[] { type, typeof(object) }, type);
        var il = dynamicMethod.GetILGenerator();
        il.Emit(OpCodes.Ldarg, 0);
        il.Emit(OpCodes.Ldarg, 1);
        il.EmitCall(OpCodes.Call, type.GetMethod(nameof(Equals), Public | Instance, null, new[] { type }, null), null);
        il.Emit(OpCodes.Ret);
            
        return (Func<ValueType, ValueType, bool>) dynamicMethod.CreateDelegate(typeof(Func<ValueType, ValueType, bool>));
    }
