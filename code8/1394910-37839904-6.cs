    // Create field to back your "myImplementation" property
    FieldBuilder newBackingField = tb.DefineField("backingField_myImplementation", typeof(MyInterface), System.Reflection.FieldAttributes.Private);
    // Create your "myImplementation" property
    PropertyBuilder newProp = tb.DefineProperty("myImplementation", System.Reflection.PropertyAttributes.None, typeof(MyInterface), Type.EmptyTypes);
    // Create get-method for your property
    MethodBuilder getter = tb.DefineMethod("get_myImplementation", System.Reflection.MethodAttributes.Private);
    ILGenerator getterILGen = getter.GetILGenerator();
    // Basic implementation (return backing field value)
    getterILGen.Emit(OpCodes.Ldarg_0);
    getterILGen.Emit(OpCodes.Ldfld, newBackingField);
    getterILGen.Emit(OpCodes.Ret);
    // Create set-method for your property
    MethodBuilder setter = tb.DefineMethod("set_myImplementation", System.Reflection.MethodAttributes.Private);
    setter.DefineParameter(1, System.Reflection.ParameterAttributes.None, "value");
    ILGenerator setterILGen = setter.GetILGenerator();
    // Basic implementation (set backing field)
    setterILGen.Emit(OpCodes.Ldarg_0);
    setterILGen.Emit(OpCodes.Ldarg_1);
    setterILGen.Emit(OpCodes.Stfld, newBackingField);
    setterILGen.Emit(OpCodes.Ret);
    // Hello1 Method
    MethodBuilder hello1 = tb.DefineMethod("Hello1", System.Reflection.MethodAttributes.Public);
    ILGenerator il = hello1.GetILGenerator();
    // Here, add code to load arguments, if any (as shown previously in answer)
    il.Emit(OpCodes.Ldarg_0);
    il.Emit(OpCodes.Call, getter);
    il.Emit(OpCodes.Callvirt, typeof(MyInterface).GetMethod("Hello1"));
    il.Emit(OpCodes.Ret);
