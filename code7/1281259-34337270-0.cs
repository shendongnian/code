    [PermissionSet(SecurityAction.Assert, Unrestricted = true)]
    internal static string GetDataDirectory() {
        if (HostingEnvironment.IsHosted)
            return Path.Combine(HttpRuntime.AppDomainAppPath, HttpRuntime.DataDirectoryName);
 
        string dataDir = AppDomain.CurrentDomain.GetData(s_strDataDir) as string;
        if (string.IsNullOrEmpty(dataDir)) {
            string appPath = null;
 
    #if !FEATURE_PAL // FEATURE_PAL does not support ProcessModule
            Process p = Process.GetCurrentProcess();
            ProcessModule pm = (p != null ? p.MainModule : null);
            string exeName = (pm != null ? pm.FileName : null);
 
            if (!string.IsNullOrEmpty(exeName))
                appPath = Path.GetDirectoryName(exeName);
    #endif // !FEATURE_PAL
 
            if (string.IsNullOrEmpty(appPath))
                appPath = Environment.CurrentDirectory;
 
            dataDir = Path.Combine(appPath, HttpRuntime.DataDirectoryName);
            AppDomain.CurrentDomain.SetData(s_strDataDir, dataDir, new FileIOPermission(FileIOPermissionAccess.PathDiscovery, dataDir));
        }
 
        return dataDir;
    }
