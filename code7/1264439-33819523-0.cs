    AppDomain currentDomain = AppDomain.CurrentDomain;
    AssemblyName enumAssembly = new AssemblyName("enumAssembly");
            
    AssemblyBuilder ab = currentDomain.DefineDynamicAssembly(
        enumAssembly, AssemblyBuilderAccess.RunAndSave);
    ModuleBuilder mb = ab.DefineDynamicModule(enumAssembly.Name, 
        enumAssembly.Name + ".dll");
    // Define a public enumeration with the name "Foo" and an 
    // underlying type of Integer.
    EnumBuilder eb = mb.DefineEnum("Foo", TypeAttributes.Public, typeof(int));
           
    var low = eb.DefineLiteral("Bar", 0);
    eb.DefineLiteral("Baz", 1);
    Type final_foo = eb.CreateType();
    ab.Save(enumAssembly.Name + ".dll");
    var converterType = typeof(TypedConverter<>);
    AssemblyName dynamicAsm = new AssemblyName();
    dynamicAsm.Name = "DynamicAsm";
    // To generate a persistable assembly, specify AssemblyBuilderAccess.RunAndSave.
    AssemblyBuilder myAsmBuilder = currentDomain.DefineDynamicAssembly(dynamicAsm,
                                                    AssemblyBuilderAccess.RunAndSave);
    // Generate a persistable single-module assembly.
    ModuleBuilder myModBuilder =
        myAsmBuilder.DefineDynamicModule(dynamicAsm.Name, dynamicAsm.Name + ".dll");
    TypeBuilder myTypeBuilder = myModBuilder.DefineType("CustomerData",
                                                    TypeAttributes.Public);
    PropertyBuilder custNamePropBldr = myTypeBuilder.DefineProperty("elevation",
                                                    PropertyAttributes.HasDefault,
                                                    final_foo,
                                                    null);
    var typedConverterType = converterType.MakeGenericType(final_foo);
    CustomAttributeBuilder attributeBuilder = new CustomAttributeBuilder(
        typeof(TypeConverterAttribute).GetConstructor(
            new Type[] { typeof(Type) }), 
            new Type[] { typedConverterType }
        );
    custNamePropBldr.SetCustomAttribute(attributeBuilder);
