    ILGenerator ilg;
    var asmName = new AssemblyName("DynamicAssembly");
    var asmBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.RunAndCollect);
    var modBuilder = asmBuilder.DefineDynamicModule("DynamicAssembly");
    var type = modBuilder.DefineType("<>CompilerFunctionClass", TypeAttributes.Class | TypeAttributes.Public);
    type.DefineDefaultConstructor(MethodAttributes.Public);
    var helloBuilder = type.DefineMethod("hello", MethodAttributes.Family | MethodAttributes.Static, typeof(void), new[] { typeof(string) });
    // emitting code for hello later
    var mainBuilder = type.DefineMethod("Main", MethodAttributes.Public);
    ilg = mainBuilder.GetILGenerator();
    ilg.Emit(OpCodes.Ldstr, "Hello, World!");
    ilg.Emit(OpCodes.Call, helloBuilder);
    ilg.Emit(OpCodes.Ret);
    // Here we emit the code for hello.
    ilg = helloBuilder.GetILGenerator();
    ilg.Emit(OpCodes.Ldarg_0);
    ilg.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine",
                new Type[] { typeof(string) }));
    ilg.Emit(OpCodes.Ret);
    // just to show it works.
    var t = type.CreateType();
    dynamic d = Activator.CreateInstance(t);
    d.Main(); // prints Hello, World!
