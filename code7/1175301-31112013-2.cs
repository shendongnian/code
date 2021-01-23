    // Add these two lines
    parms.ReferencedAssemblies.Add("System.dll");
    parms.ReferencedAssemblies.Add("System.Core.dll");
    // This line is yours
    CodeDomProvider compiler = CSharpCodeProvider.CreateProvider("CSharp");
