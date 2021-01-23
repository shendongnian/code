    var options = new CompilerParameters();
    // add all loaded assemblies
    options.ReferencedAssemblies.AddRange(
        AppDomain.CurrentDomain.GetAssemblies().Where(item => !item.IsDynamic).Select(item => item.Location).ToArray());
    options.GenerateExecutable = false;
    options.GenerateInMemory = true;
    // compile like this
    var result = provider.CompileAssemblyFromSource(options, source);
    if (result.Errors.HasErrors)
    {
        // deal with errors
    }
