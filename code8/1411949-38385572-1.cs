    private string AssemblyLocation()
    {
        var codebase = new Uri(Assembly.GetExecutingAssembly().CodeBase);
        return Path.GetDirectoryName(codebase.LocalPath);
    }
