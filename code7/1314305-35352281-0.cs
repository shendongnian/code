    string exePath = Assembly.GetExecutingAssembly().Location;
    string exeDir = Path.GetDirectoryName(exePath);
    AssemblyName[] assemRefs = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
    List<string> references = new List<string>();
    foreach (AssemblyName assemblyName in assemRefs)
        references.Add(assemblyName.Name + ".dll");
    for (int i = 0; i < references.Count; i++)
    {
        var assName = references[i];
        string localName = Path.Combine(exeDir, assName);
        if (File.Exists(localName))
            assName = localName;
        references[i] = assName;
    }
    references.Add(exePath);
    CompilerParameters compiler_parameters = new CompilerParameters(references.ToArray())
