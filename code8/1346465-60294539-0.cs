    private const string AssemblyName = "MyAssembly"; // Name of your assembly
    public Version GetVersion()
    {
        // Get all the assemblies currently loaded in the application domain.
        Assembly[] assemblies = Thread.GetDomain().GetAssemblies();
        for (int i = 0; i < assemblies.Length; i++)
        {
            if (string.Compare(assemblies[i].GetName().Name, AssemblyName) == 0)
            {
                return assemblies[i].GetName().Version;
            }
        }
        return Assembly.GetExecutingAssembly().GetName().Version; // return current version assembly or return null;
    }
