    bool IsDotNetAssembly = false;
    try
    {
        AssemblyName a = AssemblyName.GetAssemblyName(FilePath);
        IsDotNetAssembly = true;
    } catch {}
