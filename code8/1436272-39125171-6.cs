     static void ChangeButtonProperties()
     {
         // Load the assembly and the main module
         string assemblyPath = $"{Environment.CurrentDirectory}\\ClassLibrary1.dll";
         var mainModule = AssemblyDefinition.ReadAssembly(assemblyPath).MainModule;
         // Get the method to change
         TypeDefinition type = mainModule.Types.First(t => t.Name == "Test");
         MethodDefinition method = type.Methods.Single(m => m.Name == "Main_Load");
         // Get the instance field of the button
         FieldDefinition btnField = type.Fields.Single(f => f.Name == "_btn");
         var controlType = mainModule.Import(typeof(Control));
         // Import relevant types
         var colorType = mainModule.Import(typeof(Color));
         var fontType = mainModule.Import(typeof(Font));
         var fonFamilyType = mainModule.Import(typeof(FontFamily));
         // Get the setters of the requested properties
         MethodDefinition setEnabled = controlType.Resolve().Methods.Single(m => m.Name == "set_Enabled");
         MethodReference setEnabledRef = mainModule.Import(setEnabled);
         MethodDefinition setForeColor = controlType.Resolve().Methods.Single(m => m.Name == "set_ForeColor");
         MethodReference setForeColorRef = mainModule.Import(setForeColor);
         MethodDefinition setFont = controlType.Resolve().Methods.Single(m => m.Name == "set_Font");
         MethodReference setFontRef = mainModule.Import(setFont);
         // Get the Font constructor. Maybe you can think of a better way
         MethodDefinition fontCtor =
             fontType.Resolve().Methods.Single(
                 m => m.IsConstructor &&
                 m.Parameters.Count == 4 &&
                 m.Parameters[0].ParameterType.Name == "FontFamily");
         MethodReference fontCtorRef = mainModule.Import(fontCtor);
         // Get the getters of the requested properties
         var getRedColor = colorType.Resolve().Methods.Single(m => m.Name == "get_Red");
         MethodReference getRedColorRef = mainModule.Import(getRedColor);
         var getFont = controlType.Resolve().Methods.Single(m => m.Name == "get_Font");
         MethodReference getFontRef = mainModule.Import(getFont);
         var getFontSize = fontType.Resolve().Methods.Single(m => m.Name == "get_Size");
         MethodReference getFontSizeRef = mainModule.Import(getFontSize);
         var getFontFamily = fontType.Resolve().Methods.Single(m => m.Name == "get_FontFamily");
         MethodReference getFontFamilyRef = mainModule.Import(getFontFamily);
         // I clear just for the example. 
         // You can keep the instructions and enter the new one before\after
         method.Body.Instructions.Clear();
         ILProcessor processor = method.Body.GetILProcessor();
         LoadInstanceField(processor, btnField);
         // Set Enabled to true
         processor.Emit(OpCodes.Ldc_I4_1);
         processor.Emit(OpCodes.Callvirt, setEnabledRef);
         LoadInstanceField(processor, btnField);
         // Set color to red
         processor.Emit(OpCodes.Call, getRedColorRef); // no need callvirt here because is static
         processor.Emit(OpCodes.Callvirt, setForeColorRef);
         LoadInstanceField(processor, btnField);
         LoadInstanceField(processor, btnField);
         // Get all parameters to create new Font object
         processor.Emit(OpCodes.Callvirt, getFontRef);
         processor.Emit(OpCodes.Callvirt, getFontFamilyRef);
         LoadInstanceField(processor, btnField);
         processor.Emit(OpCodes.Callvirt, getFontRef);
         processor.Emit(OpCodes.Callvirt, getFontSizeRef);
         processor.Emit(OpCodes.Ldc_I4_1); // Load 1. It's the enum value of FontStyle.Bold
         processor.Emit(OpCodes.Ldc_I4_2); // Load 2. It's the enum value of GraphicsUnit.Pixel
         // Call Font constructor
         processor.Emit(OpCodes.Newobj, fontCtorRef);
         // Set the font
         processor.Emit(OpCodes.Callvirt, setFontRef);
         processor.Emit(OpCodes.Ret); // Return from the method
         method.Body.OptimizeMacros();
         mainModule.Write(assemblyPath + ".new.dll"); // Save the new dll
     }
     static void LoadInstanceField(ILProcessor processor, FieldDefinition field)
     {
         processor.Emit(OpCodes.Ldarg_0); // Load this
         processor.Emit(OpCodes.Ldfld, field); // Load button field
     }
