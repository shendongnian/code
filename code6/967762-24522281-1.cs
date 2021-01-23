    private static CompilerResults Build(string source, string fileName, bool disableTaskManager)
    {
        CompilerParameters parameters = new CompilerParameters()
        {
            CompilerOptions = disableTaskManager ? "/define:DISABLETASKMGR" : ""
            GenerateExecutable = true,
            ReferencedAssemblies = { "System.dll", "System.Windows.Forms.dll" },
            OutputAssembly = fileName,
            TreatWarningsAsErrors = false
        };
        CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
        return provider.CompileAssemblyFromSource(parameters, source);
    } 
