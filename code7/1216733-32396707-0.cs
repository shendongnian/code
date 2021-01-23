    var uri = new Uri(System.Reflection.Assembly.GetCallingAssembly().CodeBase);
    var baseDir = System.IO.Path.GetDirectoryName(uri.LocalPath);
    if (baseDir != null)
    {
        var appLocation = System.IO.Path.Combine(baseDir, "MyApp.dll");
        version = System.Diagnostics.FileVersionInfo.GetVersionInfo(appLocation).FileVersion;
    }
