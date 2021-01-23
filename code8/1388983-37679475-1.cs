    public void InterceptPropertyGetter()
    {
        // get the module where the property exist
        var module = ModuleDefinition.ReadModule(@"C:\temp\ClassLibrary1.dll");
        // get the property get method
        TypeDefinition myType = module.Types.First(type => type.Name == "Class1");
        var property = 
            myType.Properties.First(prop => prop.Name == "DataString").GetMethod;
        // get the _dataString field
        FieldDefinition dataStringDef = 
            myType.Fields.First(field => field.Name == "_dataString");
        FieldReference dataStringRef = module.Import(dataStringDef);
        // get the PropertyLogging static method
        MethodDefinition propertyLoggingDef = 
            myType.Methods.First(method => method.Name == "PropertyLogging");
        MethodReference propertyLoggingRef = module.Import(propertyLoggingDef);
        // clear the method (variables and instructions )
        property.Body.Variables.Clear();
        property.Body.Instructions.Clear();
        // define and init the locals values
        property.Body.InitLocals = true;
        var tempVar = new VariableDefinition("temp", module.TypeSystem.String);
        property.Body.Variables.Add(tempVar);
        var temp2Var = new VariableDefinition("temp2", module.TypeSystem.String);
        property.Body.Variables.Add(temp2Var);
        // write the IL
        var processor = property.Body.GetILProcessor();
        processor.Emit(OpCodes.Ldarg_0);
        processor.Emit(OpCodes.Ldfld, dataStringRef);
        processor.Emit(OpCodes.Stloc_0);
        processor.Emit(OpCodes.Ldstr, "DataString");
        processor.Emit(OpCodes.Ldloca_S, tempVar);
        processor.Emit(OpCodes.Call, propertyLoggingRef);
        processor.Emit(OpCodes.Ldloc_0);
        processor.Emit(OpCodes.Stloc_1);
        processor.Emit(OpCodes.Ldloc_1);
        processor.Emit(OpCodes.Ret);
        // save the new module
        module.Write(@"C:\temp\ClassLibrary1_new.dll");
    }
