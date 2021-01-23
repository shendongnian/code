    private static void InitConfiguration()
    {
        var map = new ExeConfigurationFileMap();
        var AssemblyConfigFile = "";
        if (File.Exists(AssemblyConfigFile))
            map.ExeConfigFilename = AssemblyConfigFile;
        else
            map.ExeConfigFilename = Path.Combine(Environment.CurrentDirectory, Environment.GetCommandLineArgs()[0]+".config");
        
        var Configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
        
        var serviceModelSectionGroup = ServiceModelSectionGroup.GetSectionGroup(Configuration);
    }
