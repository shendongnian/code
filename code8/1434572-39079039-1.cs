     private static void CallEqualityComparerDefault()
     {
         string assemblyPath = $"{Environment.CurrentDirectory}\\ClassLibrary1.dll";
         var mainModule = AssemblyDefinition.ReadAssembly(assemblyPath).MainModule;
         var methodDef = mainModule.Types.First(
             type => type.Name == "TestClass").Methods.Single(m => m.Name == "TestMethod");
         var eq = mainModule.Import(typeof(EqualityComparer<>));
         var obj = mainModule.Import(typeof(object));
         var genericEq = new GenericInstanceType(eq);
         genericEq.GenericArguments.Add(obj);
         var importedGenericEq = mainModule.Import(genericEq);
         var defaultMethodDef = importedGenericEq.Resolve().Methods.Single(m => m.Name == "get_Default");
         var methodRef =  mainModule.Import(defaultMethodDef);
         methodRef.DeclaringType = importedGenericEq;
         var ilProcessor = methodDef.Body.GetILProcessor();
         ilProcessor.InsertBefore(
             ilProcessor.Body.Instructions.First(), 
             Instruction.Create(OpCodes.Callvirt, methodRef));
         methodDef.Body.OptimizeMacros();
         mainModule.Write(assemblyPath + ".new.dll");
     }
