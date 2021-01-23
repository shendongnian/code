    var typeToLoad = typeof(Foo);
    var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("Dynamic"), AssemblyBuilderAccess.Run);
    var moduleBuilder = assemblyBuilder.DefineDynamicModule("Dynamic");
    var typeBuilder = moduleBuilder.DefineType(typeToLoad.Name, TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AnsiClass | TypeAttributes.AutoClass, typeToLoad);
    // create a constructor that doesn't call the base constructor
    var constructorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.RTSpecialName | MethodAttributes.SpecialName, CallingConventions.Standard, Type.EmptyTypes);
    var ilGenerator = constructorBuilder.GetILGenerator();
    ilGenerator.Emit(OpCodes.Ret);
    // create a factory method so we could create a delegate for it
    var methodBuilder = typeBuilder.DefineMethod("Create", MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.HideBySig, typeBuilder, Type.EmptyTypes);
    ilGenerator = methodBuilder.GetILGenerator();
    ilGenerator.Emit(OpCodes.Newobj, constructorBuilder);
    ilGenerator.Emit(OpCodes.Ret);
    var generatedType = typeBuilder.CreateType();
    var factory = (Func<Foo>)generatedType.GetMethod("Create", BindingFlags.Public | BindingFlags.Static).CreateDelegate(typeof(Func<Foo>));
