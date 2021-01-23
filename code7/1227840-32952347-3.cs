    private static TypeBuilder GetTypeBuilder()
    {
        var typeSignature = "SomeEventName";
        var an = new AssemblyName(typeSignature);
        AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(an, AssemblyBuilderAccess.Run);
                ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("TypeOfTest");
        TypeBuilder tb = moduleBuilder.DefineType(typeSignature
            , TypeAttributes.Public |
            TypeAttributes.Class |
            TypeAttributes.AutoClass |
            TypeAttributes.AnsiClass |
            TypeAttributes.BeforeFieldInit |
            TypeAttributes.AutoLayout, 
            typeof(TestBase),
            null);
                
        return tb;
    }
