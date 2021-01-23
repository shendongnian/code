    string configPath = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath;
    XDocument config = XDocument.Load(configPath);
    XElement diagnostics = config.Descendants().FirstOrDefault(e => e.Name == "system.diagnostics");
    if (diagnostics == default(XElement))
    {
        /// <system.diagnostics> element was not found in config
    }
    else
    {
        /// make changes within <system.diagnostics> here...
    }
    config.Save(configPath);
    Trace.Refresh();  /// reload the trace configuration
