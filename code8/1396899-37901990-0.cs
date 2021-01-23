    var assembly = AssemblyDefinition.ReadAssembly(inputPath);
    var module = assembly.MainModule;
    var sorted = module.Types.OrderBy(t => t.FullName).ToList();
    module.Types.Clear();
    foreach (var type in sorted)
    {
        module.Types.Add(type);
    }
    assembly.Write(outputPath);
