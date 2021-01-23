    string _assemblyName = ConfigurationManager.AppSettings["MailLogger.AssemblyName"];
    string _className = ConfigurationManager.AppSettings["MailLogger.ClassName"];
    string _assemblyPath = ConfigurationManager.AppSettings["Reporting.Assembly.Folder"];
    
    if (string.IsNullOrWhiteSpace(_assemblyName) || string.IsNullOrWhiteSpace(_className))
        throw new ApplicationException("Missing configuration data for the Logger.");
    
    Assembly _loggingAssembly = Assembly.LoadFrom(System.IO.Path.Combine(_assemblyPath, _assemblyName));
    ILogger _logger = _loggingAssembly.CreateInstance(_className) as ILogger;
    
    if (_logger == null)
        throw new ApplicationException(
                string.Format("Unable to instantiate ILogger instance from {0}/{1}", _assemblyName, _className));
    
    return _logger;
