    public static int fNew(int n)
    {
        var da = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("tempAsm"),
            AssemblyBuilderAccess.RunAndSave);
        var dm = da.DefineDynamicModule("tempAsm", "tempAsm.dll");
        var dt = dm.DefineType("dynType");
        var d = dt.DefineMethod("f", MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.HideBySig,
            CallingConventions.Standard, typeof (int), new[] {typeof (int)});
        var il = d.GetILGenerator();
        il.DeclareLocal(typeof (int[]));
        il.DeclareLocal(typeof (int));
        var range = typeof (Enumerable).GetMethod(nameof(Enumerable.Range));
        var toArray = typeof (Enumerable).GetMethod(nameof(Enumerable.ToArray)).MakeGenericMethod(typeof (int));
        var max = typeof (Enumerable).GetMethod(nameof(Enumerable.Max),
            new[] {typeof (IEnumerable<>).MakeGenericType(typeof (int))});
        if (range == null || toArray == null || max == null) throw new Exception();
        var branchTarget = il.DefineLabel();
        il.Emit(OpCodes.Nop);
        il.Emit(OpCodes.Ldc_I4_0);
        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Call, range);
        il.Emit(OpCodes.Call, toArray);
        il.Emit(OpCodes.Stloc_0);
        il.Emit(OpCodes.Ldloc_0);
        il.Emit(OpCodes.Call, max);
        il.Emit(OpCodes.Stloc_1);
        il.Emit(OpCodes.Br_S, branchTarget);
        il.MarkLabel(branchTarget);
        il.Emit(OpCodes.Ldloc_1);
        il.Emit(OpCodes.Ret);
        var bakedType = dt.CreateType();
        da.Save("tempAsm.dll");
        var x = bakedType.GetMethod("f");
        return (int) x.Invoke(null, new object[] {n});
    }
