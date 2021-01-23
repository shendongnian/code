    CSharpCodeProvider provider = new CSharpCodeProvider();
    // Build the parameters for source compilation.
    CompilerParameters cp = new CompilerParameters();
    // Add an assembly reference.
    cp.ReferencedAssemblies.Add( "System.dll" );
    // Generate an executable instead of 
    // a class library.
    cp.GenerateExecutable = true;
    // Set the assembly file name to generate.
    cp.OutputAssembly = exeFile;
    // Save the assembly as a physical file.
    cp.GenerateInMemory = false;
    // Invoke compilation.
    CompilerResults cr = provider.CompileAssemblyFromFile(cp, sourceFile);
