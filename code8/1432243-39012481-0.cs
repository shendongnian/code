    AssemblyBuilder assembly = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("Name"), AssemblyBuilderAccess.Run);
    ModuleBuilder module = assembly.DefineDynamicModule("Module");
    TypeBuilder type = module.DefineType("Type");
    PropertyBuilder property = type.DefineProperty("Property", PropertyAttributes.None, typeof(void), new Type[0]);
    Type createdType = type.CreateType();
    PropertyInfo createdProperty = createdType.GetTypeInfo().DeclaredProperties.First();
    Console.WriteLine(createdProperty.GetGetMethod(true) == null);
    Console.WriteLine(createdProperty.GetSetMethod(true) == null);
