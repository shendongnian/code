        CSharpCodeProvider prov = new CSharpCodeProvider();
        CompilerResults results = prov.CompileAssemblyFromFile(new System.CodeDom.Compiler.CompilerParameters(), new string[] { "c:\\temp\\code.txt" });
        if (results.Errors.Count == 0)
        {
            Assembly assembly = results.CompiledAssembly;
            foreach (Type type in assembly.GetTypes())
            {
                Console.WriteLine("Type: {0}", type.Name);
                foreach (PropertyInfo pi in type.GetProperties())
                {
                    Console.WriteLine("    Property: {0}, Return Type: {1}", pi.Name, pi.PropertyType);
                }
            }
        }
