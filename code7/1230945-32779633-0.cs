    object CreatePropertiesFromValues(params object[] args) {
       // Code to emit new type...
    
        int index = 0;
        foreach (object arg in args) {
            var name = index.ToString();
            var type = typeof(object); // We don't need strongly typed object!
            var field = typeBuilder.DefineField("_" + name, type, FieldAttributes.Private);
    
            var property = typeBuilder.DefineProperty(name, PropertyAttributes.HasDefault, type, null);
    
            var method = typeBbuilder.DefineMethod("get_" + name,
                MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig,
                type, Type.EmptyTypes);
        
            var generator = method.GetILGenerator();
            generator .Emit(OpCodes.Ldarg_0);
            generator .Emit(OpCodes.Ldfld, field);
            generator .Emit(OpCodes.Ret);
    
            property.SetGetMethod(method);
    
            ++index;
        }
    
        // Code to create an instance of this new type and to set
        // property values (up to you if adding a default constructor
        // with emitted code to initialize each field or using _plain_
        // Reflection).
    }
