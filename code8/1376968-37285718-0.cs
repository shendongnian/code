    public static MethodInfo CreateMethodInfo(string script, string className, string methodName)
    {
        using (var compiler = new CSharpCodeProvider())
        {
            var parms = new CompilerParameters
            {
                GenerateExecutable = false,
                GenerateInMemory = true,
                ReferencedAssemblies = { "System.Drawing.dll" }
            };
            return compiler.CompileAssemblyFromSource(parms, script)
                .CompiledAssembly.GetType(className)
                .GetMethod(methodName);
        }
    }
