    value = CreateTransformMethodInfo(_script.ScriptBody).Invoke(null, args.Select(x => x.Value).ToArray()); //args would be the arguments in your script
    public static MethodInfo CreateTransformMethodInfo(string script)
        {
            using (var compiler = new CSharpCodeProvider())
            {
                var parms = new CompilerParameters
                {
                    GenerateExecutable = false,
                    GenerateInMemory = true,
                    CompilerOptions = "/optimize",
                    ReferencedAssemblies = { "System.Core.dll" }
                };
                
                return compiler.CompileAssemblyFromSource(parms, script)
                    .CompiledAssembly.GetType("Transform")
                    .GetMethod("Execute");
            }
        }
