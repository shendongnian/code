    DynamicMethod method =
        new DynamicMethod("Test" , typeof(int[,]), new Type[]{});
    var generator = method.GetILGenerator();
    var constructor = typeof (int[,])
        .GetConstructor(new {typeof (int), typeof (int)});
    var set_method = typeof(int[,])
        .GetMethod("Set", new[] { typeof(int), typeof(int), typeof(int) });
    var local = generator.DeclareLocal(typeof (int[,]));
    generator.Emit(OpCodes.Ldc_I4_2);
    generator.Emit(OpCodes.Ldc_I4_2);
    generator.Emit(OpCodes.Newobj, constructor);
    generator.Emit(OpCodes.Stloc, local);
    generator.Emit(OpCodes.Ldloc, local);
    generator.Emit(OpCodes.Ldc_I4_1);
    generator.Emit(OpCodes.Ldc_I4_1);
    generator.Emit(OpCodes.Ldc_I4_2);
    generator.Emit(OpCodes.Call, set_method);
    generator.Emit(OpCodes.Ldloc, local);
    generator.Emit(OpCodes.Ret);
    var result_method = (Func<int[,]>)method.CreateDelegate(typeof (Func<int[,]>));
    var result = result_method(); //returns the array
