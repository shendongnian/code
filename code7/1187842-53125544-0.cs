    using (AssemblyDefinition a = AssemblyDefinition.ReadAssembly(file, new ReaderParameters { ReadWrite = true }))
    {
        var assemblyFileVersionCtor = a.CustomAttributes.Where(attribute => attribute.AttributeType.FullName == typeof(AssemblyFileVersionAttribute).FullName)
            .FirstOrDefault();
        if (assemblyFileVersionCtor != null)
        {
            assemblyFileVersionCtor.ConstructorArguments[0] = new CustomAttributeArgument(a.MainModule.TypeSystem.String, versionToSet.ToString());
            a.Write();
        }
    }
