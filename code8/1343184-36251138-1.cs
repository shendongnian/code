    DynamicMethod method =
        new DynamicMethod("Test" , typeof(int[,]), new Type[]{});
    var generator = method.GetILGenerator();
    //get the constructor that takes in 2 integers (the dimensions of the array)
    var constructor = typeof (int[,])
        .GetConstructor(new {typeof (int), typeof (int)});
    //get the Set method that takes in 3 integers; 2 indexes and the value 
    var set_method = typeof(int[,])
        .GetMethod("Set", new[] { typeof(int), typeof(int), typeof(int) });
    var local = generator.DeclareLocal(typeof (int[,])); //local variable to reference the array
    generator.Emit(OpCodes.Ldc_I4_2);
    generator.Emit(OpCodes.Ldc_I4_2);
    generator.Emit(OpCodes.Newobj, constructor); //invoke the constructor to create the array
    generator.Emit(OpCodes.Stloc, local);
    generator.Emit(OpCodes.Ldloc, local);
    generator.Emit(OpCodes.Ldc_I4_1);
    generator.Emit(OpCodes.Ldc_I4_1);
    generator.Emit(OpCodes.Ldc_I4_2);
    generator.Emit(OpCodes.Call, set_method); //call the Set method to set the value
    generator.Emit(OpCodes.Ldloc, local);
    generator.Emit(OpCodes.Ret);
    var result_method = (Func<int[,]>)method.CreateDelegate(typeof (Func<int[,]>));
    var result = result_method(); //returns the array
