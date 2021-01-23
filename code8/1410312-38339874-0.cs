    var assemblyBuilder =
        AppDomain.CurrentDomain.DefineDynamicAssembly(
            new AssemblyName {Name = "MyNewAssembly"},
            AssemblyBuilderAccess.Run);
    var moduleBuilder = assemblyBuilder.DefineDynamicModule("MyNewModule");
