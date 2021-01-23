     private static void ChangeButtonProperties()
     {
         // Load the assembly and the main module
         string assemblyPath = $"{Environment.CurrentDirectory}\\ClassLibrary1.dll";
         var mainModule = AssemblyDefinition.ReadAssembly(assemblyPath).MainModule;
         // Get the method to change
         TypeDefinition type = mainModule.Types.First(t => t.Name == "Test");
         MethodDefinition method = type.Methods.Single(m => m.Name == "Main_Load");
         // Get the instance field of the button
         FieldDefinition btnField = type.Fields.Single(f => f.Name == "_btn");
         // Get the setters of the requested properties
         MethodDefinition setEnabled = btnField.FieldType.Resolve().Methods.Single(m => m.Name == "set_Enabled");
         MethodDefinition setName = btnField.FieldType.Resolve().Methods.Single(m => m.Name == "set_Name");
         // I clear just for the example. 
         // You can keep the instructions and enter the new one before\after
         method.Body.Instructions.Clear();
         ILProcessor processor = method.Body.GetILProcessor();
         processor.Emit(OpCodes.Ldarg_0); // Load this
         processor.Emit(OpCodes.Ldfld, btnField); // Load button field
         processor.Emit(OpCodes.Ldc_I4_1); // Load 1\true
         processor.Emit(OpCodes.Callvirt, setEnabled); // Set Enabled to true
         processor.Emit(OpCodes.Ldfld, btnField); // Load button field
         processor.Emit(OpCodes.Ldstr, "Cecil rocks!"); // Load literal string
         processor.Emit(OpCodes.Callvirt, setName); // Set Name
         // put here all the rest if you need
         processor.Emit(OpCodes.Ret); // Return from the method
         method.Body.OptimizeMacros();
         mainModule.Write(assemblyPath + ".new.dll"); // Save the new dll
     }
