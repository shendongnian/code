    // Work in progress!
    public static string ReadConfigurationFile(
        string configurationFileName,
        string root,
        string section,
        string name)
    {
        string currentDirectory = Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().Location);
        var fullConfigPath = Path.Combine(
            Directory.GetParent(currentDirectory),
            configurationFolder,
            configurationFileName);
    
        var configXml = XDocument.Load(fullConfigPath);
        return configXml.Descendants(root)
                        .Descendants(section)
                        .Select(x => x.Element(name).Attribute("value").Value
                        .First();
    }
