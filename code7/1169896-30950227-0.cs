    private static Assembly CompileSource( string sourceCode )
    {
       CodeDomProvider cpd = new CSharpCodeProvider();
       CompilerParameters cp = new CompilerParameters();
       cp.ReferencedAssemblies.Add("System.dll");
       //cp.ReferencedAssemblies.Add("ClassLibrary1.dll");
       cp.GenerateExecutable = false;
       // Invoke compilation.
       CompilerResults cr = cpd.CompileAssemblyFromSource(cp, sourceCode);
    
       return cr.CompiledAssembly;
    }
