        AppDomain domain = AppDomain.CurrentDomain;
        AssemblyBuilder wrapperAssembly =
            domain.DefineDynamicAssembly(asmName,
                AssemblyBuilderAccess.RunAndSave);
        var assemblyPath = asmName.Name + ".dll";
        ModuleBuilder wrapperModule =
            wrapperAssembly.DefineDynamicModule(asmName.Name,
               assemblyPath);
        // Define a type to contain the method.
        TypeBuilder typeBuilder =
            wrapperModule.DefineType("Dyn", TypeAttributes.Public);
        MethodAttributes atts = MethodAttributes.Public | MethodAttributes.Static;
        MethodBuilder methodBuilder =
         typeBuilder.DefineMethod($"IsRuntimeType",
                                    atts,
                                    typeof(object),
                                    new[] { typeof(Type) });
        methodBuilder.DefineParameter(1, ParameterAttributes.None, "type");
        ILGenerator il = methodBuilder.GetILGenerator();
        var assem = typeof(string).Assembly;
        var t = assem.GetType("System.RuntimeType");
        var nestedList = t.GetMembers();
        var resolveType = typeof(Type).GetMethod("GetType", new[] { typeof(string) });//., BindingFlags.Static | BindingFlags.Public);
        var opEqual = typeof(Type).GetMethod("op_Equality");
        var getTypeHandle = typeof(Type).GetMethod("GetTypeFromHandle");
        var runtimeType = Type.GetType("System.RuntimeType");
        var listBuilderType = (TypeInfo)runtimeType.GetMember("ListBuilder`1",
            BindingFlags.Public | BindingFlags.NonPublic)[0];
        var ListBuilderOfStringType = listBuilderType.MakeGenericType(new[] { typeof(string) });
        // From C#
        /*
        var ctor = listBuilderType.GetConstructor(new[] { typeof(int) });
        var instance = Activator.CreateInstance(ListBuilderOfStringType, new object[] { 0 });
        */
        var listBuilderCtorArgs = new[] { typeof(Type), typeof(object[]) };
        var ctor = typeof(Activator).GetMethod("CreateInstance", listBuilderCtorArgs);
        // Generate an MSIL example of working with the RuntimeType for comparison
        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldtoken, runtimeType);
        il.Emit(OpCodes.Call, getTypeHandle);
        il.Emit(OpCodes.Call, opEqual);
        il.Emit(OpCodes.Pop);
        // Generate an MSIL of creating RuntimeType.ListBuilder<string>
        il.Emit(OpCodes.Ldtoken, ListBuilderOfStringType);
        il.Emit(OpCodes.Call, getTypeHandle);
        il.Emit(OpCodes.Ldc_I4_1);
        il.Emit(OpCodes.Newarr, typeof(object));
        il.Emit(OpCodes.Dup);
        il.Emit(OpCodes.Ldc_I4_0);
        il.Emit(OpCodes.Ldc_I4_0);
        il.Emit(OpCodes.Box, typeof(int));
        il.Emit(OpCodes.Stelem_Ref);
        il.Emit(OpCodes.Call, ctor);
        il.Emit(OpCodes.Ret);
        var result = typeBuilder.CreateType();
        wrapperAssembly.Save(assemblyPath);
        var method = result.GetMethod("IsRuntimeType", BindingFlags.Public | BindingFlags.Static);
        var stringType = typeof(string);
        var listBuilderOfStringInstance = method.Invoke(null, new[] { stringType });
