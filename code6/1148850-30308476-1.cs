    public static int GetManagedSize(Type type)
    {
        var method = new DynamicMethod("GetManagedSizeImpl", typeof(uint), new Type[0], 
            GetType().Assembly, false);
        ILGenerator gen = method.GetILGenerator();
        gen.Emit(OpCodes.Sizeof, type);
        gen.Emit(OpCodes.Ret);
        var func = (Func<uint>)method.CreateDelegate(typeof(Func<uint>));
        return checked((int)func());
    }
