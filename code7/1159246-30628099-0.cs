    using System.Reflection;
    
    ....
    
    string path = Assembly.GetExecutingAssembly().Location;
    FileVersionInfo versioninfo = FileVersionInfo.GetVersionInfo(path);
    
    return fvi.FileVersion; // type: string
