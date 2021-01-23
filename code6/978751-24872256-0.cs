    public CompilerResults CompileSource(string sourceCode)
    {
            var csc = new CSharpCodeProvider(
                new Dictionary<string, string>() { { "CompilerVersion", "v4.0" } });
            var referencedAssemblies =
                    AppDomain.CurrentDomain.GetAssemblies()
                    .Where(a => !a.FullName.StartsWith("mscorlib", StringComparison.InvariantCultureIgnoreCase))
                    .Where(a => !a.IsDynamic) //necessary because a dynamic assembly will throw and exception when calling a.Location
                    .Select(a => a.Location)
                    .ToArray();
            var parameters = new CompilerParameters(
                referencedAssemblies);
            return csc.CompileAssemblyFromSource(parameters,
                sourceCode);
     }
