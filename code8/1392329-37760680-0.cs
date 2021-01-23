            Console.WriteLine("> INJECTING INTO 12345.EXE..." + Environment.NewLine);
            AssemblyDefinition asm = AssemblyDefinition.ReadAssembly(@"C:\dummy.exe");
            var writeLineMethod = typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) });
            var writeLineRef = asm.MainModule.Import(writeLineMethod);
            var pStartMethod = typeof(Process).GetMethod("Start", new Type[] { typeof(string) });
            var pStartRef = asm.MainModule.Import(pStartMethod);
            foreach (var typeDef in asm.MainModule.Types)
            {
                foreach (var method in typeDef.Methods) 
                {
                    //Let's push a string using the Ldstr Opcode to the stack
                    method.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Ldstr, "INJECTED!"));
                    //We add the call to the Console.WriteLine() method. It will read from the stack
                    method.Body.Instructions.Insert(1, Instruction.Create(OpCodes.Call, writeLineRef));
                    //We push the path of the executable you want to run to the stack
                    method.Body.Instructions.Insert(2, Instruction.Create(OpCodes.Ldstr, @"calc.exe"));
                    //Adding the call to the Process.Start() method, It will read from the stack
                    method.Body.Instructions.Insert(3, Instruction.Create(OpCodes.Call, pStartRef));
                    //Removing the value from stack with pop
                    method.Body.Instructions.Insert(4, Instruction.Create(OpCodes.Pop));
                }
            }
            asm.Write("12345.exe"); //Now we just save the new assembly
