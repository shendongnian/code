    CSharpCodeProvider provider = new CSharpCodeProvider();
    CompilerParameters parameters = new CompilerParameters();
    parameters.GenerateInMemory = true;                
    //The next line is the addition to the original code
    parameters.ReferencedAssemblies.Add(Assembly.GetEntryAssembly().Location);
